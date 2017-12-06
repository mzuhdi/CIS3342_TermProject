<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignmentPage.aspx.cs" Inherits="TermProject.AssignmentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="CreateAssignmentDiv" runat="server" visible="false">
        <h1>Create Assignment</h1>
        <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Label ID="lblDueDate" runat="server" Text="Due Date:"></asp:Label>
        <asp:Calendar ID="calendarDueDate" runat="server"></asp:Calendar>
        <asp:Label ID="lblMaximumGrade" runat="server" Text="Maximum Grade: "></asp:Label>
        <asp:TextBox ID="txtMaxGrade" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" Text="Create Assignment" OnClick="btnSubmit_Click" />
        <asp:Label ID="lblSuccess" runat="server" ></asp:Label>
    </div>
    <div id="uploadexample" runat="server" visible="true">
           <asp:Label ID="lblStatus" runat="server"    
            style="z-index: 1; left: 35px; top: 253px; position: absolute; width: 334px; height: 34px;"
            Font-Bold="True" ForeColor="#003366"></asp:Label>
      
        <asp:Label ID="Label4" runat="server"
            style="z-index: 1; left: 34px; top: 146px; position: absolute; width: 145px; right: 810px;"
            Text="Title:"></asp:Label>
 
   
        <asp:Label ID="Label2" runat="server"
            style="z-index: 1; left: 35px; top: 111px; position: absolute; width: 145px; right: 491px;"
            Text="Image:"></asp:Label>
 
 
        <asp:FileUpload ID="FileUpload1" runat="server"
                style="z-index: 1; left: 96px; top: 108px; position: absolute; width: 400px; right: 493px;" />
 
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large"
                   style="z-index: 1; left: 38px; top: 27px; position: absolute; width: 819px; height: 56px"
                   Text="The page demonstrates the use of storing a product image into a database."></asp:Label>
       
       
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="FileUpload1" ErrorMessage="*** no image selected"
                Font-Bold="True" style="z-index: 1; left: 505px; top: 108px; position: absolute"></asp:RequiredFieldValidator>--%>
       
        <asp:TextBox ID="txtTitle" runat="server"  
                style="z-index: 1; left: 95px; top: 145px; position: absolute; width: 216px;"></asp:TextBox>
 
        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="ddlProducts" ErrorMessage="*** no product selected"
                Font-Bold="True"
                style="z-index: 1; left: 252px; top: 196px; position: absolute"></asp:RequiredFieldValidator>--%>
 
 
        <asp:Button ID="btnUpload" runat="server"
                    style="z-index: 1; left: 35px; top: 315px; position: absolute; width: 136px; height: 25px;"
                    Text="Upload Image" OnClick="btnUpload_Click" />
 
   <%--     <asp:DropDownList ID="ddlProducts" runat="server"
                            style="z-index: 1; left: 35px; top: 219px; position: absolute;">
        </asp:DropDownList>--%>
   
   
        <asp:Label ID="Label3" runat="server"
            style="z-index: 1; left: 34px; top: 194px; position: absolute; width: 260px; right: 695px;"
            Text="Select a product for image upload:"></asp:Label>
    </div>
    <div id="gvAssignmentDiv" runat="server">
        <asp:GridView ID="gvAssignment" runat="server"></asp:GridView>
        <asp:Button ID="btnDownload" runat="server" Text="download" OnClick="btnDownload_Click" />
    </div>
</asp:Content>
