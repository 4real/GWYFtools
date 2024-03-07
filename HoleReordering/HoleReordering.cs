using System.Text;

namespace HoleReordering
{
    public partial class HoleReordering : Form
    {
        private bool HasLoadedMap;
        private string? LoadedRawData;
        private string[]? MapDataParts;
        private Hole[]? Holes;

        public HoleReordering()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            mapFilename.Text = openDialog.FileName;
            TryReload();
        }

        private void HoleReordering_Load(object sender, EventArgs e)
        {
            ClearMap();

            var localLow = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
#if WINDOWS //TBH I have no idea if Linux is even supported by GWYF, not appending Low seems like a slightly worse guess then
            localLow += "Low";
#endif
            openDialog.InitialDirectory = Path.Combine(localLow, "Team17 Digital Ltd", "Golf With Your Friends", "CustomLevels");
        }

        private void TryReload()
        {
            ClearMap();

            try
            {
                LoadedRawData = File.ReadAllText(mapFilename.Text);
                MapParser.ParseMapData(LoadedRawData, out MapDataParts, out Holes);

                if (Holes != null)
                {
                    HasLoadedMap = true;

                    foreach (var hole in Holes)
                    {
                        holes.Items.Add(hole);
                    }

                    UpdateVisualStates();
                }
            }
            catch (IOException)
            {
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            TryReload();
        }

        private void ClearMap()
        {
            HasLoadedMap = false;
            holes.Items.Clear();
            UpdateVisualStates();
        }

        private void UpdateVisualStates()
        {
            saveButton.Enabled = HasLoadedMap;

            if (HasLoadedMap)
            {
                if (GetMapData() == LoadedRawData)
                    unsavedChanges.Text = "No unsaved changes.";
                else
                    unsavedChanges.Text = "UNSAVED changes!";
            }
            else
            {
                unsavedChanges.Text = "No course map loaded.";
            }

            bool holeSelected = holes.SelectedItem != null;
            upButton.Enabled = holeSelected;
            downButton.Enabled = holeSelected;
            par.Enabled = holeSelected;

            if (holeSelected)
            {
                par.Value = ((Hole)holes.SelectedItem).Par;
            }
        }

        private string GetMapData()
        {
            if (!HasLoadedMap)
                throw new InvalidOperationException("Need to load map first");

            var buffer = new StringBuilder(MapDataParts[0]);

            for (int i = 0; i < holes.Items.Count; ++i)
            {
                buffer.Append(((Hole)holes.Items[i]).Object);
                buffer.Append(MapDataParts[i + 1]);
            }

            return buffer.ToString();
        }

        private void holes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVisualStates();
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            var selected = holes.SelectedItem;
            if (selected == null)
                return;

            int insertIndex = holes.SelectedIndex - 1;
            if (insertIndex < 0)
                return;

            holes.Items.Remove(selected);
            holes.Items.Insert(insertIndex, selected);
            holes.SelectedItem = selected;
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            var selected = holes.SelectedItem;
            if (selected == null)
                return;

            int insertIndex = holes.SelectedIndex + 1;
            if (insertIndex >= holes.Items.Count)
                return;

            holes.Items.Remove(selected);
            holes.Items.Insert(insertIndex, selected);
            holes.SelectedItem = selected;
        }

        private void par_ValueChanged(object sender, EventArgs e)
        {
            var selected = (Hole)holes.SelectedItem;
            if (selected == null)
                return;

            selected.Par = (int)par.Value;

            //cruft because ObjectCollection does not implement IEnumerable<object>
            var oldItems = new List<object>();
            foreach (var item in holes.Items)
                oldItems.Add(item);
            holes.Items.Clear();
            holes.Items.AddRange(oldItems.ToArray());
            holes.SelectedItem = selected;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!HasLoadedMap)
                return;

            try
            {
                var data = GetMapData();
                File.WriteAllText(mapFilename.Text, data);
                LoadedRawData = data;
                UpdateVisualStates();
            }
            catch (IOException)
            {
            }
        }
    }
}
