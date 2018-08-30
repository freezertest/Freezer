//ciao


$(document).ready(function () {
    $("#addingform").hide();
    $("#foodlist").hide();
    $("#errorspace").hide();
    $("#successpace").hide();
    $('#invalid').css("display", "none");
    $('#foodfilteredlist').hide();
    $('#pantry').hide();
    $('.rbtn').hide();


    //--change section----------------------------------------------------------------
    $("#changesection").click(function () {
        if ($("#pantry").is(':hidden') == true)
            $("#pantry").show();
        else
            $('#pantry').hide();
    });

    //--"Aggiungi" click------------------------------------------------------------------------
    $("#btnadd").click(function () {
        LoadFreezers();
        $('#freezer').change(function () {
            var id = $('#freezer').val();
            LoadDrawers(id);
        });

        LoadTypes();
        LoadPortions();
        $('#pantry').hide();
        $("#foodlist").hide();
        $('#foodfilteredlist').hide();
        $("#successpace").hide();
        $('.rbtn').hide();
        $('#invalid').css("display", "none");
        $("#addingform").show();
    });
    //--"Inserisci!" click------------------------------------------------------------
    $("#insertbtn").click(function () {
        alert("click");
        var row = {};
        row.Name = $("#foodname").val();
        row.Type = $("#foodtype").val();
        row.Portion = $("#foodportion").val();
        row.Freezer = $("#freezer").val();
        row.Drawer = $("#drawer").val();
        row.Notes = $("#notes").val();
        row = JSON.stringify(row);
        $.ajax({
            url: "https://localhost:5001/api/food",
            type: "post",
            data: row,
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                if (response.toUpperCase().includes("SUCCESSO") == true) {
                    $("#successmessage").html(response);
                    $("#successpace").show();
                    $("#addingform").hide();
                }
                else {
                    $("#errormessage").html(response);
                    $("#errorspace").show();
                    $('#invalid').css("display", "block");
                }

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $("#errormessage").html(errorThrown + "<br/>Non hai riempito qualche campo!");
                $("#errorspace").show();
            }
        });
    });
    //--"LISTA" click-------------------------------------------------------------------------------------------
    $("#btnlist").click(function () {
        $("#addingform").hide();
        $('#pantry').hide();
        $("#errorspace").hide();
        $('#invalid').css("display", "none");
        LoadList();

        $("#foodlist").show();
    });

    //--"DELETE" click----------------------------------------------------------------------------------
    $("#btndelete").click(function () {
        $("#addingform").hide();
        $("#errorspace").hide();
        $('#pantry').hide();
        $('#invalid').css("display", "none");
        if ($('#foodfilteredlist').is(":hidden") == true && $('#foodlist').is(":hidden") == true) {
            LoadListD();
            $("#foodlist").show();
        }
        if ($(".rbtn").is(':hidden') == true)
            $('.rbtn').show();
        else
            $('.rbtn').hide();
    });
    //--"ELIMINA(BIDONCINO)" click------------------------------------------------------------------------
    $('.rbtn').click(function () {
        chosen = $(this).attr('id');
        $.ajax({
            type: "DELETE",
            url: 'https://localhost:5001/api/food' + chosen,
            data: { _method: 'delete', _token: token },
            success: function (response) {
                $("#successmessage").html(response);
                $('#foodfilteredlist').hide();
                $('#foodlist').hide();
                $("#successpace").show();

            },
            error: function (response) {
                $('#foodfilteredlist').hide();
                $('#foodlist').hide();
                $("#errormessage").html(response);
                $("#errorspace").show();
            }
        });
    });

    //--"SEARCH" click----------------------------------------------------------------------------------
    $("#researchbtn").click(function () {
        $('.rbtn').hide();
        $('#pantry').hide();
        if ($("#research").css("visibility") == "visible")
            $("#research").css("visibility", "hidden");
        else
            $("#research").css("visibility", "visible");
    });
    //--"INVIO RICERCA" click---------------------------------------------------------------------------
    $("#researchimpbtn").click(function (e) {
        e.preventDefault();
        $('#foodfilteredtable').html('');
        $('#foodfilteredlist').hide();
        var searchTerm = $("#researchtext").val();
        var filteredList = [];
        var portions = [];
        var types = [];
        $.ajax({
            url: "https://localhost:5001/api/searchtype/" + searchTerm,
            type: 'GET',
            async: false,
            dataType: 'json', // added data type
            success: function (data1) {
                filteredList = data1;
                $.ajax({
                    url: "https://localhost:5001/api/portions",
                    type: 'GET',
                    async: false,
                    dataType: 'json', // added data type
                    success: function (data2) {
                        portions = data2;
                        $.ajax({
                            url: "https://localhost:5001/api/types",
                            type: 'GET',
                            async: false,
                            dataType: 'json', // added data type
                            success: function (data3) {
                                types = data3;
                            }
                        });
                    }
                });
            }
        });
        $('#termsearched').append(searchTerm);
        if (searchTerm.toUpperCase() == "PESCE" || searchTerm.toUpperCase() == "CARNE" || searchTerm.toUpperCase() == "LEGUMI" || searchTerm.toUpperCase() == "VERDURA" || searchTerm.toUpperCase().contains("ERBE" || "SPEZIE") == true || searchTerm.toUpperCase() == "ALTRO") {
            if (Array.isArray(filteredList) == false) {
                if (filteredList.toUpperCase().contains('INESISTENTE')) {
                    $("#errormessage").html("Puoi cercare per tipo o per porzioni. Sei sicuro di aver digitato correttamente?")
                    $("#errorspace").show();
                }
                if (filteredList.toUpperCase().contains('NON SONO PRESENTI ALIMENTI')) {
                    $("#errormessage").html(data);
                    $("#errorspace").show();
                }
            }

            for (var i = 0; i < portions.length; i++) {
                $('#foodfilteredtable').append('<thead><tr><td class="table-info" scope="col" id="' + portions[i].Name + '">' + portions[i].Name + '</td></tr><tr><td scope="col">Nome</td><td scope="col">Freezer</td><td scope="col">Cassetto</td><td scope="col">Note</td><td scope="col"> </td></tr></thead><tbody id="' + portions[i].Name + 'body">');
                for (var j = 0; j < filteredList.length; j++) {
                    if (filteredList[j].Portion.toUpperCase() == portions[i].Name.toUpperCase())
                        $('#' + portions[i].Name + 'body').append('<tr><td>' + filteredList[j].Name + '</td><td>' + filteredList[j].FreezerName + '</td><td>' + filteredList[j].DrawerName + '</td><td>' + filteredList[j].Notes + '</td><td><button type="button" class="btn btn-danger rbtn" id="' + filteredList[j].Id + '"><span class="far fa-trash-alt" ></span></button></td></tr>');
                }
            }
            $('#foodfilteredtable').append('</tbody>');
            $('#foodfilteredlist').show();
        }
        else {
            if (searchTerm.toUpperCase() == "X1" || searchTerm.toUpperCase() == "X2" || searchTerm.toUpperCase() == "X3") {
                if (filteredList.toUpperCase().contains('INESISTENTE')) {
                    $("#errormessage").html("Puoi cercare per tipo o per porzioni. Sei sicuro di aver digitato correttamente?")
                    $("#errorspace").show();
                }

                for (var i = 0; i < types.length; i++) {
                    $('#foodfilteredtable').append('<thead><tr><td class="table-info" scope="col" id="' + types[i].Name + '"></td></tr><tr><td scope="col">Nome</td><td scope="col">Freezer</td><td scope="col">Cassetto</td><td scope="col">Note</td><td scope="col"> </td></tr></tr></thead><tbody id="' + types[i].Name + 'body">');
                    for (var j = 0; j < filteredList.length; j++) {
                        if (filteredList[j].Type.toUpperCase() == types[i].Name.toUpperCase())
                            $('#' + types[i].Name + 'body').append('<tr><td>' + filteredList[j].Name + '</td><td>' + filteredList[j].FreezerName + '</td><td>' + filteredList[j].DrawerName + '</td><td>' + filteredList[j].Notes + '</td><td><button type="button" class="btn btn-danger rbtn" Id="' + filteredList[j].Id + '"><span class="far fa-trash-alt "></span></button></td></tr>');
                    }
                }
                $('#foodfilteredtable').append('</tbody>');
                $('#foodfilteredlist').show();
            }
            else {
                $("#errormessage").html("Puoi cercare per tipo o per porzioni. Sei sicuro di aver digitato correttamente?")
                $("#errorspace").show();
            }
        }
    });

    //--HOMEPAGE click---------------------------------------------------------------------------------------------------------------------------
    $('#homepage').click(function () {
        window.location.href = "https://localhost:5001/indexFreeeze.html";
    });
    //--CLOSE click-----------------------------------------------------------------------------------------------------------------------------------------
    $('.clse').click(function () {
        $('#errorspace').hide();
        $('#successpace').hide();
    });
});
//-------------------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------------------
//-----------OUT OF DOC.READY()----------------------------------------------------------------------------------------

//FUNCTIONS LOAD FORM
function LoadFreezers() {
    $.get("https://localhost:5001/api/freezer", function (data) {
        for (var i = 0; i < data.length; i++)
            $("#freezer").append('<option value="' + data[i].Id + '">' + data[i].Name + '</option>');
    });
};

function LoadDrawers(freezerId) {
    $.get("https://localhost:5001/api/drawers/" + freezerId, function (data) {
        for (var i = 0; i < data.length; i++)
            $("#drawer").append('<option value="' + data[i].Id + '">' + data[i].Name + '</option>');
    })
};

function LoadTypes() {
    $.get("https://localhost:5001/api/types", function (data) {
        for (var i = 0; i < data.length; i++)
            $("#foodtype").append('<option value="' + data[i].Id + '">' + data[i].Name + '</option>');
    })
};

function LoadPortions() {
    $.get("https://localhost:5001/api/portions", function (data) {
        for (var i = 0; i < data.length; i++)
            $("#foodportion").append('<option value="' + data[i].Id + '">' + data[i].Name + '</option>');
    })
};

//LOAD COMMON LIST
function LoadList() {
    $.get("https://localhost:5001/api/freezer", function (fr) {
        for (var i = 0; i < fr.length; i++) {
            $("#foodlist").append('<div id="' + fr[i].Name.toLowerCase().replace(/\s+/, "") + 'list"><h2 id="' + fr[i].Name.toLowerCase() + 'title">' + fr[i].Name + '</h2><table class="table table-striped" id="' + fr[i].Name.toLowerCase().replace(/\s+/, "") + 'table"></table></div>');
            var sHtml;
            for (var j = 0; j < fr[i].Drawers.length; j++) {
                sHtml += '<thead><tr><td class="table-info" scope="col">' + fr[i].Drawers[j].Name.toLowerCase() + '</td></tr><tr><td scope="col">Nome</td><td scope="col">Tipo</td><td scope="col">Porzione</td><td scope="col">Note</td><td> </td></tr></thead><tbody>';
                if (fr[i].Drawers[j].DrawerFood.length <= 0)
                    sHtml += '<tr><td colspan="4">Non ci sono alimenti in questo cassetto</tr></td></tbody>';

                for (var m = 0; m < fr[i].Drawers[j].DrawerFood.length; m++)
                    sHtml += '<tr><td>' + fr[i].Drawers[j].DrawerFood[m].Name + '</td><td>' + fr[i].Drawers[j].DrawerFood[m].Type.Name + '</td><td>' + fr[i].Drawers[j].DrawerFood[m].Portion.Name + '</td><td>' + fr[i].Drawers[j].DrawerFood[m].Notes + '</td><td><button type="button" class="btn btn-danger rbtn" id="' + fr[i].Drawers[j].DrawerFood[m].Id + '"><span class="far fa-trash-alt "></span></button></td></tr>';
                $('#' + fr[i].Name.toLowerCase().replace(/\s+/, "") + 'list').append('</tbody>');
            }
            $('#' + fr[i].Name.toLowerCase().replace(/\s+/, "") + 'table').append(sHtml + '</table>');
            sHtml = '';
        }
        $('.rbtn').hide();
    });
}

function LoadListD() {
    $.get("https://localhost:5001/api/freezer", function (fr) {
        for (var i = 0; i < fr.length; i++) {
            $("#foodlist").append('<div id="' + fr[i].Name.toLowerCase().replace(/\s+/, "") + 'list"><h2 id="' + fr[i].Name.toLowerCase() + 'title">' + fr[i].Name + '</h2><table class="table table-striped" id="' + fr[i].Name.toLowerCase().replace(/\s+/, "") + 'table"></table></div>');
            var sHtml;
            for (var j = 0; j < fr[i].Drawers.length; j++) {
                sHtml += '<thead><tr><td class="table-info" scope="col">' + fr[i].Drawers[j].Name.toLowerCase() + '</td></tr><tr><td scope="col">Nome</td><td scope="col">Tipo</td><td scope="col">Porzione</td><td scope="col">Note</td><td> </td></tr></thead><tbody>';
                if (fr[i].Drawers[j].DrawerFood.length <= 0)
                    sHtml += '<tr><td colspan="4">Non ci sono alimenti in questo cassetto</tr></td></tbody>';

                for (var m = 0; m < fr[i].Drawers[j].DrawerFood.length; m++)
                    sHtml += '<tr><td>' + fr[i].Drawers[j].DrawerFood[m].Name + '</td><td>' + fr[i].Drawers[j].DrawerFood[m].Type.Name + '</td><td>' + fr[i].Drawers[j].DrawerFood[m].Portion.Name + '</td><td>' + fr[i].Drawers[j].DrawerFood[m].Notes + '</td><td><button type="button" class="btn btn-danger rbtn" id="' + fr[i].Drawers[j].DrawerFood[m].Id + '"><span class="far fa-trash-alt "></span></button></td></tr>';
                $('#' + fr[i].Name.toLowerCase().replace(/\s+/, "") + 'list').append('</tbody>');
            }
            $('#' + fr[i].Name.toLowerCase().replace(/\s+/, "") + 'table').append(sHtml + '</table>');
            sHtml = '';
        }
        $('.rbtn').show();
    });
}