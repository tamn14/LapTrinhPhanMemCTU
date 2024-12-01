using QuanLyDichBenh.DTO;

public class GiongLua
{
    public int GiongLuaID { get; set; }
    public string TenGiong { get; set; }
    public MuaVu muaVu { get; set; }

    public GiongLua(int giongLuaID, string tenGiong)
    {
        GiongLuaID = giongLuaID;
        TenGiong = tenGiong;
    }

    public GiongLua(int giongLuaID, string tenGiong , MuaVu muaVu)
    {
        GiongLuaID = giongLuaID;
        TenGiong = tenGiong;
        this.muaVu = muaVu; 
    }

    public GiongLua() { }   

    public GiongLua( string tenGiong , MuaVu muaVu)
    {
        
        TenGiong = tenGiong;
        this.muaVu = muaVu;
    }
}
