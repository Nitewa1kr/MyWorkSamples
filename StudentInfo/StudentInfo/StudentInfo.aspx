<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="StudentInfo.StudentInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/Styles/MyStylesheet.css" />
    <link rel="stylesheet" type="text/css" href="/Styles/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="/Styles/template.css" />
    <link rel="stylesheet" type="text/css" href="/Styles/validationEngine.jquery.css" />

    <script src="/Scripts/jquery.validationEngine.js"></script>
    <script src="/Scripts/jquery-1.8.2.min.js"></script>
    <script src="/Scripts/jquery-2.2.3.js"></script>
    <script src="/Scripts/jquery-ui.js"></script>
    
    <script src="/Scripts/myJS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="myStyle">
            <tr>
                <td>
                    <asp:Label ID="sNUM" runat="server" Text="STUDENT ID"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:Label class="myText" ID="lblS_NUM" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="FNAME" runat="server" Text="FIRST NAME"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox class="myText" CssClass="validate[required]" ID="txtfname" runat="server" ></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="LNAME" runat="server" Text="LAST NAME"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox class="myText" CssClass="validate[required]" ID="txtlname" runat="server" ></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="DOB" runat="server" Text="DATE OF BIRTH"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox class="myText" CssClass="validate[required,funcCall[DateFormat[]]" ID="txtDOB" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="SDATE" runat="server" Text="START DATE"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox class="myText" CssClass="validate[required,funcCall[DateFormat[]]" ID="txtSDATE" runat="server"></asp:TextBox>
                </td>
            </tr>

        </table>

        <table class="myStyle">
            
            <tr>
                <td>
                    <asp:Label ID="cid" runat="server" Text="COURSE ID"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblC_ID" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label class="myText" CssClass="validate[required]" ID="cname" runat="server" Text="COURSE NAME"></asp:Label>
                </td>
                <td class="myText">
                    <asp:DropDownList ID="txtCourseName" runat="server" Height="20px" Width="125px">
                        <asp:ListItem>Network Engineering</asp:ListItem>
                        <asp:ListItem>Software Engineering</asp:ListItem>    
                        <asp:ListItem>Database Architect</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

        <table class="myStyle">
            <tr>
                <td>
                    <asp:Label ID="mid" runat="server" Text="MARKS ID"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblM_ID" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="assignments" runat="server" Text="ASSIGNMENTS"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox class="myText" ID="txtAssign" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="tests" runat="server" Text="TESTS"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox class="myText" ID="txtTests" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="exams" runat="server" Text="EXAMS"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox class="myText" ID="txtExams" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="tot" runat="server" Text="TOTAL MARKS"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox class="myText" ID="txtTot" Enabled="false" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table class="myStyle">
            <tr>
                <td>
                    <asp:Button ID="btnADD" runat="server" Text="ADD" Width="70px" OnClick="btnADD_Click" />
                    <asp:Button ID="btnUPDATE" runat="server" Text="UPDATE" style="margin-left: 0px" Width="100px" OnClick="btnUPDATE_Click" />
                    <asp:Button ID="btnDEL" runat="server" Text="DELETE" OnClick="btnDEL_Click" />
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblResult" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="S_NUM,C_ID,M_ID" DataSourceID="SqlDataSource1" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="S_NUM" HeaderText="S_NUM" ReadOnly="True" SortExpression="S_NUM" />
                            <asp:TemplateField HeaderText="S_FNAME" SortExpression="S_FNAME">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("S_FNAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="FNAME" runat="server" Text='<%# Bind("S_FNAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S_LNAME" SortExpression="S_LNAME">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("S_LNAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LNAME" runat="server" Text='<%# Bind("S_LNAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S_DOB" SortExpression="S_DOB">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("S_DOB") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="DOB" runat="server" Text='<%# Bind("S_DOB") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S_SDATE" SortExpression="S_SDATE">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("S_SDATE") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="SDATE" runat="server" Text='<%# Bind("S_SDATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="C_ID" HeaderText="C_ID" SortExpression="C_ID" ReadOnly="True" />
                            <asp:TemplateField HeaderText="COURSE_NAME" SortExpression="COURSE_NAME">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("COURSE_NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="CNAME" runat="server" Text='<%# Bind("COURSE_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="M_ID" HeaderText="M_ID" SortExpression="M_ID" ReadOnly="True" />
                            <asp:TemplateField HeaderText="M_ASSIGNMENTS" SortExpression="M_ASSIGNMENTS">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("M_ASSIGNMENTS") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="ASSIGN" runat="server" Text='<%# Bind("M_ASSIGNMENTS") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="M_TESTS" SortExpression="M_TESTS">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("M_TESTS") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="TESTS" runat="server" Text='<%# Bind("M_TESTS") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="M_EXAMS" SortExpression="M_EXAMS">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("M_EXAMS") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="EXAMS" runat="server" Text='<%# Bind("M_EXAMS") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="M_TOTAL" SortExpression="M_TOTAL">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("M_TOTAL") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="TOTAL" runat="server" Text='<%# Bind("M_TOTAL") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StudentConnectionString %>" SelectCommand="SELECT STUDENT.S_NUM, STUDENT.S_FNAME, STUDENT.S_LNAME, STUDENT.S_DOB, STUDENT.S_SDATE, COURSE.C_ID, COURSE.COURSE_NAME, MARKS.M_ID, MARKS.M_ASSIGNMENTS, MARKS.M_TESTS, MARKS.M_EXAMS, MARKS.M_TOTAL FROM STUDENT CROSS JOIN COURSE CROSS JOIN MARKS WHERE S_NUM= C_ID AND C_ID=M_ID"></asp:SqlDataSource>

                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
