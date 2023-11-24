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
            //{
            //    new StupaBabiYagi(12),
            //    new HutOnChikenLegs(14, 20),
            //    new FlyingShip(10),
            //    new Centaur(15,15),
            //    new CarriagePumpkin(11,17),
            //    new CarpetPlane(15),
            //    new Broomstick(11),
            //    new BootsFastwalkers(13,19)
            //};

            radioButton1.Checked = true;
            label_count.Text = "�������: 0";
        }

        // Ground
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _type = (int)TYPE_RACE.GROUND;
            air_groupBox.Enabled = false;
            ground_groupBox.Enabled = true;
            Reset();
        }

        // Air
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _type = (int)TYPE_RACE.AIR;
            air_groupBox.Enabled = true;
            ground_groupBox.Enabled = false;
            Reset();
        }

        // Mixed
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            _type = (int)TYPE_RACE.MIXED;
            air_groupBox.Enabled = true;
            ground_groupBox.Enabled = true;
            Reset();
        }

        private void ViewCountVehicles()
        {
            label_count.Text = $"�������: {vehicles.Count}";
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

        // Events checkbox
        private void stupa_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            if (isChecked) vehicles.Add(new StupaBabiYagi(12));
            else
            {
                IVehicle stupaBabiYagi = vehicles.FirstOrDefault(v => v is StupaBabiYagi);

                // ���� ������ ������, ������� ��� �� ������
                if (stupaBabiYagi != null)
                {
                    vehicles.Remove(stupaBabiYagi);
                }
            }

            ViewCountVehicles();
        }

        private void broom_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            if (isChecked) vehicles.Add(new Broomstick(11));
            else
            {
                IVehicle broomstick = vehicles.FirstOrDefault(v => v is Broomstick);

                // ���� ������ ������, ������� ��� �� ������
                if (broomstick != null)
                {
                    vehicles.Remove(broomstick);
                }
            }

            ViewCountVehicles();
        }

        private void carpet_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            if (isChecked) vehicles.Add(new CarpetPlane(15));
            else
            {
                IVehicle carpet = vehicles.FirstOrDefault(v => v is CarpetPlane);

                // ���� ������ ������, ������� ��� �� ������
                if (carpet != null)
                {
                    vehicles.Remove(carpet);
                }
            }

            ViewCountVehicles();
        }

        private void flyingShip_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            if (isChecked) vehicles.Add(new FlyingShip(10));
            else
            {
                IVehicle ship = vehicles.FirstOrDefault(v => v is FlyingShip);

                // ���� ������ ������, ������� ��� �� ������
                if (ship != null)
                {
                    vehicles.Remove(ship);
                }
            }

            ViewCountVehicles();
        }

        private void boots_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            if (isChecked) vehicles.Add(new BootsFastwalkers(13, 19));
            else
            {
                IVehicle boots = vehicles.FirstOrDefault(v => v is BootsFastwalkers);

                // ���� ������ ������, ������� ��� �� ������
                if (boots != null)
                {
                    vehicles.Remove(boots);
                }
            }

            ViewCountVehicles();
        }

        private void chiken_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            if (isChecked) vehicles.Add(new HutOnChikenLegs(14, 20));
            else
            {
                IVehicle chiken = vehicles.FirstOrDefault(v => v is HutOnChikenLegs);

                // ���� ������ ������, ������� ��� �� ������
                if (chiken != null)
                {
                    vehicles.Remove(chiken);
                }
            }

            ViewCountVehicles();
        }

        private void centaur_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            if (isChecked) vehicles.Add(new Centaur(15, 15));
            else
            {
                IVehicle centaur = vehicles.FirstOrDefault(v => v is Centaur);

                // ���� ������ ������, ������� ��� �� ������
                if (centaur != null)
                {
                    vehicles.Remove(centaur);
                }
            }

            ViewCountVehicles();
        }

        private void pumpkin_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            if (isChecked) vehicles.Add(new CarriagePumpkin(11, 17));
            else
            {
                IVehicle pumpkin = vehicles.FirstOrDefault(v => v is CarriagePumpkin);

                // ���� ������ ������, ������� ��� �� ������
                if (pumpkin != null)
                {
                    vehicles.Remove(pumpkin);
                }
            }

            ViewCountVehicles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vehicles.Count == 0) MessageBox.Show("������������ �������� �� �������!", "������!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
    }
}