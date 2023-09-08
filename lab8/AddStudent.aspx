<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="lab8.AddStudent" MasterPageFile="~/layot.Master" %>

<asp:Content ID="cntTitle" ContentPlaceHolderID="cphTitle" runat="server">
   AddStudent
</asp:Content>

<asp:Content ID="cncTitle" ContentPlaceHolderID="cphContent" runat="server">
    <div class="object-fit-cover border rounded">
        <label for="txtName" class="form-label">Student Name </label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName"
            runat="server"
            controlToValidate="txtName"
            cssclass="text-danger"
            Display="Dynamic"
            EnableClientScript="true">
            Required!
        </asp:RequiredFieldValidator>

        <label>Student Type</label>
        <asp:DropDownList ID="ddpList" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvType"
            runat="server"
            controlToValidate="ddpList"
            cssclass="text-danger"
            Display="Dynamic"
            EnableClientScript="true">
            Must select one!
        </asp:RequiredFieldValidator>
    </div>

    <div>
        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary m-3" OnClick="Add_Student" />
    </div>
</asp:Content>

<asp:Content ID="cnl" ContentPlaceHolderID="cphLast" runat="server">
    <asp:Table ID="tblDetails" runat="server" class="table-primary table table-striped display-6"></asp:Table>
    <div>
        <a href="RegisterCourse.aspx" target="_blank" class="fs-4-bold">Register Course</a>
    </div>
</asp:Content>
