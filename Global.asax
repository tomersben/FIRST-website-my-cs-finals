<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        Application["TotalUserCounter"] = 0;

    }
    
    void Application_End(object sender, EventArgs e) 
    {


    }
        
    void Application_Error(object sender, EventArgs e) 
    { 

    }

    void Session_Start(object sender, EventArgs e) 
    {
        Application.Lock();
            
        int count = (int)Application["TotalUserCounter"];
        Application["TotalUserCounter"] = count + 1;
            
            Application.UnLock();
    }

    void Session_End(object sender, EventArgs e) 
    {
         Application.Lock();
     
    int count = (int)Application["TotalUserCounter"];
    Application["TotalUserCounter"] = count - 1;
     
     Application.UnLock();

        
    }
       
</script>
