using Racing.Data;
using Racing.Interfaces;
using Racing.Models;
using Racing.Services;
using System.Windows.Forms;

namespace Racing
{
    public partial class Form1 : Form
    {
        private List<IVehicle> vehicles;
        private int _type = (int)TYPE_RACE.NOT_FOUND;

        public Form1()
        {
            InitializeComponent();

            vehicles = new List<IVehicle>();
            radioButton1.Checked = true;
            label_count.Text = "Выбрано: 0";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _type = (int)TYPE_RACE.GROUND;
            air_groupBox.Enabled = false;
            ground_groupBox.Enabled = true;
            Reset();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _type = (int)TYPE_RACE.AIR;
            air_groupBox.Enabled = true;
            ground_groupBox.Enabled = false;
            Reset();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            _type = (int)TYPE_RACE.MIXED;
            air_groupBox.Enabled = true;
            ground_groupBox.Enabled = true;
            Reset();
        }

        private void ViewCountVehicles()
        {
            label_count.Text = $"Выбрано: {vehicles.Count}";
        }

        private void Reset()
        {
            vehicles.Clear();
            stupa_checkBox.Checked = false;
            broom_checkBox.Checked = false;
            carpet_checkBox.Checked = false;
            flyingShip_checkBox.Checked = false;
            boots_checkBox.Checked = false;
            pumpkin_checkBox.Checked = false;
            chiken_checkBox.Checked = false;
            centaur_checkBox.Checked = false;
        }

        private void CheckBoxChanged(bool isChecked, string vehicle)
        {
            if (isChecked)
            {
                if (vehicle == VehicleNames.StupaBabiYagi) vehicles.Add(new StupaBabiYagi(12));
                else if (vehicle == VehicleNames.Broomstick) vehicles.Add(new Broomstick(11));
                else if (vehicle == VehicleNames.CarpetPlane) vehicles.Add(new CarpetPlane(15));
                else if (vehicle == VehicleNames.FlyingShip) vehicles.Add(new FlyingShip(10));
                else if (vehicle == VehicleNames.BootsFastwalkers) vehicles.Add(new BootsFastwalkers(13, 19));
                else if (vehicle == VehicleNames.HutOnChikenLegs) vehicles.Add(new HutOnChikenLegs(14, 20));
                else if (vehicle == VehicleNames.Centaur) vehicles.Add(new Centaur(15, 15));
                else if (vehicle == VehicleNames.CarriagePumpkin) vehicles.Add(new CarriagePumpkin(11, 17));
            }
            else
            {
                IVehicle obj = vehicles.FirstOrDefault(v => v.Name == vehicle);
                if (obj != null) vehicles.Remove(obj);
            }

            ViewCountVehicles();
        }

        private void stupa_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            CheckBoxChanged(isChecked, VehicleNames.StupaBabiYagi);
        }

        private void broom_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            CheckBoxChanged(isChecked, VehicleNames.Broomstick);
        }

        private void carpet_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            CheckBoxChanged(isChecked, VehicleNames.CarpetPlane);
        }

        private void flyingShip_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            CheckBoxChanged(isChecked, VehicleNames.FlyingShip);
        }

        private void boots_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            CheckBoxChanged(isChecked, VehicleNames.BootsFastwalkers);
        }

        private void chiken_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            CheckBoxChanged(isChecked, VehicleNames.HutOnChikenLegs);
        }

        private void centaur_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            CheckBoxChanged(isChecked, VehicleNames.Centaur);
        }

        private void pumpkin_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            CheckBoxChanged(isChecked, VehicleNames.CarriagePumpkin);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (vehicles.Count == 0) MessageBox.Show("Транспортные средства не выбраны!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ITrack track;
            switch (_type)
            {
                case (int)TYPE_RACE.GROUND:
                    var ground = vehicles.OfType<IGroundVehicle>().ToList();
                    track = new GroundTrack((double)trackBar1.Value * 100, ground);
                    FillDataGrid(track);
                    break;

                case (int)TYPE_RACE.AIR:
                    var air = vehicles.OfType<IAirVehicle>().ToList();
                    track = new AirTrack((double)trackBar1.Value * 100, air);
                    FillDataGrid(track);
                    break;

                case (int)TYPE_RACE.MIXED:
                    var g = vehicles.OfType<IGroundVehicle>().ToList();
                    var a = vehicles.OfType<IAirVehicle>().ToList();
                    track = new MixedTrack((double)trackBar1.Value * 100, g, a);
                    FillDataGrid(track);
                    break;

                default:
                    return;
            }            
        }

        private void FillDataGrid(ITrack track)
        {
            RaceService srv = new RaceService(track);
            var dict = srv.StartRace();
            dataGridView1.Rows.Clear();

            int idx = 0;
            foreach (var d in dict)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, idx].Value = d.Key;
                dataGridView1[1, idx].Value = Math.Round(d.Value, 2);
                dataGridView1[2, idx].Value = idx + 1;
                idx++;
            }

        }
    }
}