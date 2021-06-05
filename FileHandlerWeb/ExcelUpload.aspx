<%@ Page Title="Excel Upload" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExcelUpload.aspx.cs" Inherits="FileHandlerWeb.ExcelUpload" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <asp:Label ID="Label" runat="server"></asp:Label>
        <br />
        <br />
        <asp:FileUpload ID="FileUploadControl" runat="server" />
        <br />
        <br />

    </div>


    <script>
        $("#MainContent_FileUploadControl").change(function () {
            if ($("#MainContent_FileUploadControl").val() == "") {
                return;
            }
            $('#MainContent_Label').html("");
            var formData = new FormData();
            var files = $('#MainContent_FileUploadControl').get(0);
            for (var i = 0; i < files.files.length; i++) {
                formData.append(files.files[i].name, files.files[i]);
            }

            $.ajax({
                url: "https://localhost:44337/FileHandler.ashx",
                type: "POST",
                contentType: false,
                processData: false,
                data: formData,
                success: function (result) {
                    var rslt = JSON.parse(result);
                    if (rslt.status == "OK") {
                        if (rslt.message != "") {
                            $('#MainContent_Label').html(rslt.message);
                        }
                        else {
                            alert("İşlem Başarılı")
                        }
                    }
                    else {
                        $('#MainContent_Label').html(rslt.message);
                    }
                },
                error: function (err) {
                    $('#MainContent_Label').html(err);
                }
            });
        });


    </script>
</asp:Content>
