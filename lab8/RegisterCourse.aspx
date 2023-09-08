<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Course</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
        <style>
        
        .header-with-background {
        height: 180px; 
        background-image: url("/images/algon.png"); 
        background-size: cover; 
        background-position: center center; 
      
        }
        #cblCourses input[type="checkbox"] {
         width: 40px; 
        height: 40px; 
        margin-right: 10px; 
        cursor: pointer;
        display: inline-block;
         vertical-align: middle; 
        }

        .fs-4-bold {
            font-size: 1.8rem; 
            font-weight: bold;
        }
        #btnAdd {
            font-size: 2rem;
        }
        .custom-checkbox-list input[type="checkbox"] {
            width: 40px; 
            height: 40px; 
            margin-right: 10px; 
        }

    </style>
</head>
<body style="background-color: #045C3E;">
     <header class="header-with-background">
 
</header>
    
    <form id="form1" runat="server" class="fs-4-bold">

        <div  class="object-fit-cover border rounded" >
            <label for="ddpStudent" class="form-label">Student </label>
            <asp:DropDownList ID="ddpStudent" runat="server"></asp:DropDownList>
          <asp:RequiredFieldValidator ID="rfvddpStudent" runat="server" InitialValue="Select.." ControlToValidate="ddpStudent" 
                 CssClass="text-danger" Display="Dynamic" EnableClientScript="true">
                 Required!
            </asp:RequiredFieldValidator>
          

         </div>
          <div>
               <p id="SummaryRegister" runat="server" class="m-3 "></p>

                

            </div>
        
        <div>
            <asp:Button ID="btnAdd" runat="server" Text="Save" CssClass="btn btn-primary m-3" OnClick="Save_Student"  />


        </div>
        <asp:CheckBoxList ID="cblCourses" runat="server"></asp:CheckBoxList>

            
        
    </form>
    
   
    <div>
            <a href="AddStudent.aspx" target="_blank" class ="fs-4-bold"> Add Student</a>
    </div>


</body>
</html>
