namespace KoczkaBalazs_241112F;

internal class Varos
{
    public string VarosNev { get; set; }
    public string OrszagNev { get; set; }
    public float Nepesseg { get; set; }
    public override string ToString() =>
        $"{VarosNev} ({OrszagNev}) Népesség: {Nepesseg:00.00} millió fő";
    public Varos(string row)
    {
        var v = row.Split(';');
        VarosNev = v[0];
        OrszagNev = v[1];
        Nepesseg = float.Parse(v[2]);
    }
}
