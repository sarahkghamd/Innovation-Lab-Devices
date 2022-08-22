﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ForgetPass1.aspx.cs" Inherits="ILD.ForgetPass1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="customizedCSS/FormsStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <br>
    <br>
        <h2> استعادة كلمة المرور </h2>
    <br>
    <br>
    <fieldset>
        <br>
        <br>
        <div class="form-group row ">
                                <asp:Label ID="Label2" class="col-sm-2 col-form-label text-center" runat="server" Text="البريد الالكتروني:"></asp:Label>
                                <div class="col-sm-10" >
                                    <input type="email" ID="useremail" class="form-control w-50" runat="server" required></div>
                                </div>     
                     
            <center>
                <br>
                <br>
                <asp:Button ID="Button1" class="btn btn-success" runat="server" OnClick="password" Text="إرسال" />
            </center>
    </fieldset>

    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="sweetalert2.all.min.js"></script>


     <script>
        function error() {
            Swal.fire({
                title: 'تم ارسال كلمة المرور بنجاح',
                icon: 'success',
                buttonsStyling: false,
                confirmButtonText: 'موافق'

            }).then(function () {
                window.location.href = 'Login.aspx';
            });
        }


        function errorInfo() {
            Swal.fire({
                title: 'خطأ!',
                text: 'البريد الالكتروني غير مسجل ',
                icon: 'error',
                buttonsStyling: false,
                confirmButtonText: 'موافق'

            })
        }

        

     </script>

</asp:Content>