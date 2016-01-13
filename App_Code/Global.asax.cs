using System;
/// </summary>
using System.Web;
/// <summary>i

/// Summary description for Global

/// </summary>

public class Global : System.Web.HttpApplication

{

    public Global()

    {

        //

        // TODO: Add constructor logic here

        //

    }



    protected void Application_Start(object sender, EventArgs e)

    {
        WebApiConfig.Register();
    }



    protected void Session_Start(object sender, EventArgs e)

    {



    }



    protected void Session_End(object sender, EventArgs e)

    {



    }



    protected void Application_End(object sender, EventArgs e)

    {



    }

}
