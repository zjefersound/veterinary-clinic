using VeterinaryClinic.Views;
using VeterinaryClinic.Utils;

Bootstrapper.ChargeClinics();
Bootstrapper.ChargeClients();
Bootstrapper.ChargeAnimals();

DashboardView dashboardView = new DashboardView();
