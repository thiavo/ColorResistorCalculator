$(document).ready(function () {

    // When the page loads set background color of the drop down list items 
    $("select").each(function () {
        setBkgColor($(this));
    });

    // When the page loads set background color of the drop down list items 
    $("select option").each(function () {
        setBkgColor($(this));
    });

    //Setting the background color to correlate with the band selected
    function setBandColor(bandObj,selectObj)
    {
        var className = bandObj.attr('class').split(' ');
        bandObj.addClass(selectObj.val()).removeClass(className[1]);
    }

    //Change the background color when there's a new selection
    $("select").change(function () {

        setBkgColor($(this));

        var obj = {
        'bandAColor':$('#ddlFirstBand').val(), 
        'bandBColor':$('#ddlSecondBand').val(), 
        'bandCColor': $('#ddlThirdBand').val(),
        'bandDColor': $('#ddlFourthBand').val()
        };

        // JSON response returned after the call with the min, max and resistor values
        $.ajax({
            type:"POST",
            url: "/Home/getResistanceValue",
            cache:false,
            dataType: "json",
            data:obj,
            success: function (r) {
                //if error
                if (r.error != undefined) {                  
                    $("#divError").html(r.error);
                }
                else {
                    $("#divError").empty();
                    $("#txtMinResistor").val(r.min);
                    $("#txtMaxResistor").val(r.max);
                    $("#txtResistorValue").val(r.main);
                }
            }
        });
    });

    // Sets the background color of the drop down list
    function setBkgColor(object) {
        var color = "black";

        //Switch statement to change the background colors for the bands upon change
        switch (object.attr('id')) {
            case "ddlFirstBand":
                setBandColor($("#divFiresultBand"), object);
                break;
            case "ddlSecondBand":
                setBandColor($("#divSecondBand"), object);
                break;
            case "ddlThirdBand":
                setBandColor($("#divThirdBand"), object);
                break;
            case "ddlFourthBand":
                setBandColor($("#divFourthBand"), object);
                break;                
            default: 
        }

        // Set background color of the drop down list items 
        if (object.val() != '') {

            object.css('background-color', object.val());

            switch (object.val()) {
                case "black":
                    color = "#FFFFFF";
                    break;
                case "red":
                    color = "#FFFFFF";
                    break;
                case "green":
                    color = "#FFFFFF";
                    break;
                case "brown":
                    color = "#FFFFFF";
                    break;
                case "blue":
                    color = "#FFFFFF";
                    break;
                case "gray":
                    color = "#FFFFFF";
                    break;
                default:

            }
            object.css('color', color);
        }
    }

})