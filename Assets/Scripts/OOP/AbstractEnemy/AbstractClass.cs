abstract class AbstractClass 
{
    public AbstractClass(float privateText, string protectedText, string abstractText)
    {
        this.privateNumber = privateText;
        this.protectedText = protectedText;
        this.abstractText = abstractText;
        
    }
    private float privateNumber = 100f;
    protected abstract string protectedText { get; set; }
    public abstract string abstractText { get; set; }
    public static string staticText { get; private set; }

    public abstract void AbstractMetod();   
    public void PublicRealMetod()  
    {
        //other logick
    }
    public static void StaticRealMetod() 
    {
        //other logick
    }

    protected abstract void ProtectedAbstractMetod();
    protected void ProtectedRealMetod()  
    {
        //other logick
    }
    private void PrivateRealMetod(float time)  
    {
        //other logick
    }
}
class NewClass : AbstractClass
{
    public NewClass(float privateText, string protectedText, string abstractText) : base(privateText, protectedText, abstractText)
    {
    }

    public override string abstractText { get; set; }
    protected override string protectedText { get; set; }

    public override void AbstractMetod()
    {
        //other logick
    }

    protected override void ProtectedAbstractMetod()
    {
        //other logick
    }
}
public class Handler
{
    private float time;
    private string text;
    private string text2;
    private void Start()
    {
        AbstractClass abstractClass = new NewClass(time, text, text2);
        abstractClass.AbstractMetod();
        abstractClass.PublicRealMetod();
        AbstractClass.StaticRealMetod();

        text = AbstractClass.staticText;
        abstractClass.abstractText = text; 
        
    }
}
