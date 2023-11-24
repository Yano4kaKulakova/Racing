using Racing.Interfaces;
using Racing.Models;

namespace Racing
{
    public partial class Form1 : Form
    {
        private List<IVehicle> vehicles;

        public Form1()
        {
            InitializeComponent();
            vehicles = new List<IVehicle>()
            {
                new StupaBabiYagi(12),
                new HutOnChikenLegs(14, 20),
                new FlyingShip(10),
                new Centaur(15,15),
                new CarriagePumpkin(11,17),
                new CarpetPlane(15),
                new Broomstick(11),
                new BootsFastwalkers(13,19)
            };
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}