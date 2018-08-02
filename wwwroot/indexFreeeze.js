$( document ).ready(function() {
    //change section
    // $("#changesection").click(function{

    // });
    //"Aggiungi" click
    $("#addingform").hide();
    $("#foodlist").hide();
    $("#errorspace").hide();
    var food=[];
    $("#btnadd").click(function(){
        $("#addingform").show();
        $("#foodlist").hide();
    });
        //"Inserisci!" click
        $("#insertbtn").click(function(){
            alert("click");
            var row={};
            row.Name=$("#foodname").val();
            row.Type=$("#foodtype").val();
            row.Portion=$("#foodportion").val();
            row.Freezer=$("#freezer").val();
            row.Drawer=$("#drawer").val();
            row.Notes=$("#notes").val();
            row=JSON.stringify(row);
            $.post("https://localhost:5001/api/freezer", row, function(result){
                console.log("POSTATO");
            });
        });
    //"LISTA" click
    $("#btnlist").click(function(){
        $("#addingform").hide();
        $("#errorspace").hide();
        $("#foodlist").show();
        $.get( "https://localhost:5001/api/freezer", function( data ) {
            LoadFrUp(data[0]);
            LoadFrPt (data[1]);
            LoadFrCant (data[2]);
            alert( "Load was performed." );
          });
    });
    //"SEARCH" click
    $("#researchbtn").click(function(){
        if($("#research").css("visibility")=="visible")
            $("#research").css("visibility", "hidden");
        else
        $("#research").css("visibility", "visible");
           
    });
    $("#researchimpbtn").click(function(){
       var searchTerm = $("#research").val();
       if(searchTerm.toUpper()=="PESCE"||searchTerm.toUpper()=="CARNE"||searchTerm.toUpper()=="LEGUMI"||searchTerm.toUpper()=="VERDURA"||searchTerm.toUpper().contains("ERBE"||"SPEZIE")==true||searchTerm.toUpper()=="ALTRO"){
        $.get( "https://localhost:5001/api/searchtype", function( data ) {
            if(data=="null"){
                $("#errormessage").html("Puoi cercare per tipo o per porzioni. Sei sicuro di aver digitato correttamente?")
                $("#errorspace").show();
            }
            else{
                LoadFrUp(data);
                LoadFrPt(data);
                LoadFrCant(data);
            }
          });
       }
       else{
            if(searchTerm.toUpper()=="X1"||searchTerm.toUpper()=="X2"||searchTerm.toUpper()=="X3"){
                $.get( "https://localhost:5001/api/searchportion", function( data ) {
                    if(data=="null"){
                        $("#errormessage").html("Puoi cercare per tipo o per porzioni. Sei sicuro di aver digitato correttamente?")
                        $("#errorspace").show();                    }
                    else{
                        LoadFrUp(data);
                        LoadFrPt(data);
                        LoadFrCant(data);
                    }
                });
            }
            else{
                $("#errormessage").html("Puoi cercare per tipo o per porzioni. Sei sicuro di aver digitato correttamente?")
                $("#errorspace").show();        
            }
        }
    });

});

//LoadFrInCommonList
function LoadFrUp(Data){
    $( "#frup" ).html( Data.freezerName);
    $( "#c1frup" ).html( Data.drawers[0].drawerName);
    if(Data.drawers[0].drawerFood.length>0){
        for(i=0; i<Data.drawers[0].drawerFood.length;i++){
            $("#c1frupbody").html('<tr><td>'+Data.drawers[0].drawerFood[i].FoodName+'</td><td>'+Data.drawers[0].drawerFood[i].FoodType+'</td><td>'+Data.drawers[0].drawerFood[i].FoodPortion+'</td><td>'+Data.drawers[0].drawerFood[i].FoodNotes+'</td></tr>')
        }
    }
    else
    $("#c1frupbody").html('<tr>Non ci sono alimenti in questo cassetto</tr>');

    $( "#c2frup" ).html( Data.drawers[1].drawerName);
    if(Data.drawers[1].drawerFood.length>0){
        for(i=0; i<Data.drawers[1].drawerFood.length;i++){
            $("#c2frupbody").html('<tr><td>'+Data.drawers[1].drawerFood[i].FoodName+'</td><td>'+Data.drawers[1].drawerFood[i].FoodType+'</td><td>'+Data.drawers[1].drawerFood[i].FoodPortion+'</td><td>'+Data.drawers[1].drawerFood[i].FoodNotes+'</td></tr>')
        }
    }
    else
    $("#c2frupbody").html('<tr>Non ci sono alimenti in questo cassetto</tr>');


    $( "#c3frup" ).html( Data.drawers[2].drawerName);
    if(Data.drawers[2].drawerFood.length>0){
        for(i=0; i<Data.drawers[2].drawerFood.length;i++){
            $("#c3frupbody").html('<tr><td>'+Data.drawers[2].drawerFood[i].FoodName+'</td><td>'+Data.drawers[2].drawerFood[i].FoodType+'</td><td>'+Data.drawers[2].drawerFood[i].FoodPortion+'</td><td>'+Data.drawers[2].drawerFood[i].FoodNotes+'</td></tr>')
        }
    }
    else
    $("#c3frupbody").html('<tr>Non ci sono alimenti in questo cassetto</tr>');
}

function LoadFrPt(Data){
    $( "#frpt" ).html( Data.freezerName);
    $( "#c1frpt" ).html( Data.drawers[0].drawerName);
    if(Data.drawers[0].drawerFood.length>0){
        for(i=0; i<Data.drawers[0].drawerFood.length;i++){
            $("#c2frptbody").html('<tr><td>'+Data.drawers[0].drawerFood[i].FoodName+'</td><td>'+Data.drawers[0].drawerFood[i].FoodType+'</td><td>'+Data.drawers[0].drawerFood[i].FoodPortion+'</td><td>'+Data.drawers[0].drawerFood[i].FoodNotes+'</td></tr>')
        }
    }
    else
    $("#c1frptbody").html('<tr>Non ci sono alimenti in questo cassetto</tr>');    
    $( "#c2frpt" ).html( Data.drawers[1].drawerName);
    if(Data.drawers[1].drawerFood.length>0){
        for(i=0; i<Data.drawers[1].drawerFood.length;i++){
            $("#c2frptbody").html('<tr><td>'+Data.drawers[1].drawerFood[i].FoodName+'</td><td>'+Data.drawers[1].drawerFood[i].FoodType+'</td><td>'+Data.drawers[1].drawerFood[i].FoodPortion+'</td><td>'+Data.drawers[1].drawerFood[i].FoodNotes+'</td></tr>')
        }
    }
    else
    $("#c2frptbody").html('<tr>Non ci sono alimenti in questo cassetto</tr>');    
    $( "#c3frpt" ).html( Data.drawers[2].drawerName);
    if(Data.drawers[2].drawerFood.length>0){
        for(i=0; i<Data.drawers[2].drawerFood.length;i++){
            $("#c3frptbody").html('<tr><td>'+Data.drawers[2].drawerFood[i].FoodName+'</td><td>'+Data.drawers[2].drawerFood[i].FoodType+'</td><td>'+Data.drawers[2].drawerFood[i].FoodPortion+'</td><td>'+Data.drawers[2].drawerFood[i].FoodNotes+'</td></tr>')
        }
    }
    else
    $("#c3frptbody").html('<tr>Non ci sono alimenti in questo cassetto</tr>');
}

function LoadFrCant(Data){
 $( "#frcant" ).html( Data.freezerName);
 $( "#c1frcant" ).html( Data.drawers[0].drawerName);
 if(Data.drawers[0].drawerFood.length>0){
     for(i=0; i<Data.drawers[0].drawerFood.length;i++){
         $("#c1frcantbody").html('<tr><td>'+Data.drawers[0].drawerFood[i].FoodName+'</td><td>'+Data.drawers[0].drawerFood[i].FoodType+'</td><td>'+Data.drawers[0].drawerFood[i].FoodPortion+'</td><td>'+Data.drawers[0].drawerFood[i].FoodNotes+'</td></tr>')
     }
 }
 else
 $("#c1frcantbody").html('<tr>Non ci sono alimenti in questo cassetto</tr>');
 
 $( "#c2frcant" ).html( Data.drawers[1].drawerName);
 if(Data.drawers[1].drawerFood.length>0){
     for(i=0; i<Data.drawers[1].drawerFood.length;i++){
         $("#c2frcantbody").html('<tr><td>'+Data.drawers[1].drawerFood[i].FoodName+'</td><td>'+Data.drawers[1].drawerFood[i].FoodType+'</td><td>'+Data.drawers[1].drawerFood[i].FoodPortion+'</td><td>'+Data.drawers[1].drawerFood[i].FoodNotes+'</td></tr>')
     }
 }
 else
 $("#c2frcantbody").html('<tr>Non ci sono alimenti in questo cassetto</tr>');

 $( "#c3frcant" ).html( Data.drawers[2].drawerName);
 if(Data.drawers[2].drawerFood.length>0){
     for(i=0; i<Data.drawers[2].drawerFood.length;i++){
         $("#c3frcantbody").html('<tr><td>'+Data.drawers[2].drawerFood[i].FoodName+'</td><td>'+Data.drawers[2].drawerFood[i].FoodType+'</td><td>'+Data.drawers[2].drawerFood[i].FoodPortion+'</td><td>'+Data.drawers[2].drawerFood[i].FoodNotes+'</td></tr>')
     }
 }
 else
 $("#c3frcantbody").html('<tr>Non ci sono alimenti in questo cassetto</tr>');
 }

//impossibile non mettere porzione se non è spezia o altro
// if( valore tipo !=5 && valore tipo !=6 && valore qtà ==0)
// document.getElementsById("invalid").setAttribute("display", "block");