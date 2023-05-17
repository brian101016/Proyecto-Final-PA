using Proyecto_Final_PA;
using System.Linq;
using System.Windows.Forms;
using System;

public class Global {

    // ########################## VARIABLES
    private ConnectionDataContext db = new ConnectionDataContext();

    // ########################## ELIMINAR VENTA
    public void Eliminar_Venta(int id, bool success = false) {
        var consulta = db.Venta.Where(v => v.ID == id);
        Eliminar_Venta(consulta, success);
    }

    public void Eliminar_Venta(IQueryable<Venta> ventas, bool success = false)
    {
        // Eliminar las ventas seleccionadas
        foreach (Venta venta in ventas) db.Venta.DeleteOnSubmit(venta);

        try {
            db.SubmitChanges();
            if (success) MessageBox.Show("Se ha(n) eliminado la(s) venta(s)!");
        } catch (Exception ex) { MessageBox.Show("Error en ventas: " + ex.Message); }
    }

    // ########################## ELIMINAR AUTO
    public void Eliminar_Auto(int id, bool success = false) {
        var consulta = db.Venta.Where(v => v.ID == id);
        Eliminar_Venta(consulta, success);
    }

    public void Eliminar_Auto(IQueryable<Auto> autos, bool success = false)
    {
        // Lista con los IDs a eliminar
        var autosIDs = autos.Select(a => a.ID).ToList();

        // Ventas que tengan referencia a algun auto a eliminar (AutoID)
        var query_ventas = db.Venta.Where(v => autosIDs.Contains(v.AutoID));
        Eliminar_Venta(query_ventas);

        // Eliminar los autos seleccionadas
        foreach (Auto auto in autos) db.Auto.DeleteOnSubmit(auto);

        try {
            db.SubmitChanges();
            if (success) MessageBox.Show("Se ha(n) eliminado el/los auto(s)!");
        } catch (Exception ex) { MessageBox.Show("Error en autos: " + ex.Message); }
    }

    // ########################## ELIMINAR PERSONA
    public void Eliminar_Persona(int id, bool success = false) {
        var consulta = db.Persona.Where(p => p.ID == id);
        Eliminar_Persona(consulta, success);
    }
    
    public void Eliminar_Persona(IQueryable<Persona> personas, bool success = false) {

        // Lista con los IDs a eliminar
        var personasIDs = personas.Select(p => p.ID).ToList();

        // Autos que tengan referencia a alguna persona a eliminar (ProveedorID)
        var query_autos = db.Auto.Where(a => personasIDs.Contains(a.ProveedorID));
        Eliminar_Auto(query_autos);

        // Ventas que tengan referencia a alguna persona a eliminar (ClienteID o VendedorID)
        var query_ventas = db.Venta.Where(
            v => personasIDs.Contains(v.ClienteID)
            || personasIDs.Contains(v.VendedorID));

        Eliminar_Venta(query_ventas);

        // Eliminar las personas seleccionadas
        foreach (Persona persona in personas) db.Persona.DeleteOnSubmit(persona);

        try {
            db.SubmitChanges();
            if (success) MessageBox.Show("Se ha(n) eliminado a la(s) persona(s)!");
        } catch (Exception ex) { MessageBox.Show("Error en personas: " + ex.Message); }

    }

    // ########################## ELIMINAR PUESTO
    public void Eliminar_Puesto(int id, bool success = false) {
        var consulta = db.Puesto.Where(p => p.ID == id);
        Eliminar_Puesto(consulta, success);
    }

    public void Eliminar_Puesto(IQueryable<Puesto> puestos, bool success = false)
    {
        // Lista con los IDs a eliminar
        var puestosIDs = puestos.Select(p => p.ID).ToList();

        // Personas que tengan referencia a algun puesto a eliminar (PuestoID)
        var query_personas = db.Persona.Where(p => puestosIDs.Contains(p.PuestoID));
        Eliminar_Persona(query_personas);

        // Eliminar los puestos seleccionados
        foreach (Puesto puesto in puestos) db.Puesto.DeleteOnSubmit(puesto);

        try {
            db.SubmitChanges();
            if (success) MessageBox.Show("Se ha(n) eliminado el/los puesto(s)!");
        } catch (Exception ex) { MessageBox.Show("Error en puestos: " + ex.Message); }
    }

    // ########################## ELIMINAR MARCA
    public void Eliminar_Marca(int id, bool success = false) {
        var consulta = db.Marca.Where(m => m.ID == id);
        Eliminar_Marca(consulta, success);
    }

    public void Eliminar_Marca(IQueryable<Marca> marcas, bool success = false)
    {
        // Lista con los IDs a eliminar
        var marcasIDs = marcas.Select(m => m.ID).ToList();

        // Autos que tengan referencia a alguna marca a eliminar (MarcaID)
        var query_autos = db.Auto.Where(a => marcasIDs.Contains(a.MarcaID));
        Eliminar_Auto(query_autos);

        // Eliminar las marcas seleccionadas
        foreach (Marca marca in marcas) db.Marca.DeleteOnSubmit(marca);

        try {
            db.SubmitChanges();
            if (success) MessageBox.Show("Se ha(n) eliminado la(s) marca(s)!");
        } catch (Exception ex) { MessageBox.Show("Error en marcas: " + ex.Message); }
    }

    // ########################## ELIMINAR CARROCERIA
    public void Eliminar_Carroceria(int id, bool success = false) {
        var consulta = db.Carroceria.Where(m => m.ID == id);
        Eliminar_Carroceria(consulta, success);
    }

    public void Eliminar_Carroceria(IQueryable<Carroceria> carrocerias, bool success = false)
    {
        // Lista con los IDs a eliminar
        var carroceriasIDs = carrocerias.Select(m => m.ID).ToList();

        // Autos que tengan referencia a alguna carroceria a eliminar (CarroceriaID)
        var query_autos = db.Auto.Where(a => carroceriasIDs.Contains(a.CarroceriaID));
        Eliminar_Auto(query_autos);

        // Eliminar las carrocerias seleccionadas
        foreach (Carroceria carroceria in carrocerias) db.Carroceria.DeleteOnSubmit(carroceria);

        try {
            db.SubmitChanges();
            if (success) MessageBox.Show("Se ha(n) eliminado la(s) carroceria(s)!");
        } catch (Exception ex) { MessageBox.Show("Error en carrocerias: " + ex.Message); }
    }

    // ########################## ELIMINAR ESTADO
    public void Eliminar_Estado(int id, bool success = false) {
        var consulta = db.Estado.Where(e => e.ID == id);
        Eliminar_Estado(consulta, success);
    }

    public void Eliminar_Estado(IQueryable<Estado> estados, bool success = false)
    {
        // Lista con los IDs a eliminar
        var estadosIDs = estados.Select(e => e.ID).ToList();

        // Ventas que tengan referencia a algun estado a eliminar (EstadoID)
        var query_estados = db.Venta.Where(e => estadosIDs.Contains(e.EstadoID));
        Eliminar_Venta(query_estados);

        // Eliminar los estados seleccionados
        foreach (Estado estado in estados) db.Estado.DeleteOnSubmit(estado);
        
        try {
            db.SubmitChanges();
            if (success) MessageBox.Show("Se ha(n) eliminado el/los estado(s)!");
        } catch (Exception ex) { MessageBox.Show("Error en estados: " + ex.Message); }
    }
}
