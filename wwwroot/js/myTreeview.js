//tree script
$(document).on("click", '.collapseNode, .collapsibleNode', function (e) {
        e.preventDefault();
       
        var a = 222222222;
        console.log(a);

        var this1 = $(this); //get Click item 
        var data = {
            pid: $(this).attr('pid')
         };
   
        var isLoaded = $(this1).attr('data-loaded'); //check data loaded or not
        if (isLoaded == "false") {
            $(this1).addClass("loadingP");   //show loading panel
            $(this1).removeClass("collapseNode");

            // Load Data  
            $.ajax({
                url: "/Treeview/GetSubNode",
                type: "GET",
                data: data,
                dataType: "json",
                success: function (d) {                    
                    $(this1).removeClass("loadingP");

                    if (d.length > 0) {
                        var $ul = $("<ul></ul>");
                        $.each(d, function (i, ele) {
                            $ul.append(
                                $("<li></li>").append(
                                    "<span class='collapseNode collapsibleNode' data-loaded='false' pid='" + ele.TreeId+"'>&nbsp;</span>" +                           
                                    "<span class='item' menuId=" + ele.TreeId + "><a>" + ele.TreeName+"</a></span>"
                                    )
                                )
                        });

                        $(this1).parent().append($ul);
                        $(this1).addClass('collapseNode');
                        $(this1).toggleClass('collapseNode expand');
                        $(this1).closest('li').children('ul').slideDown();
                    }
                    else {
                        // no sub tree
                        $(this1).css({'display':'inline-block','width':'15px'});
                    }

                    $(this1).attr('data-loaded', true);
                },
                error: function (xhr, status, error) { alert('Error:' + status + ' ' + error + ' ' + xhr); }
            }); 
        }
        else {
            // if data loaded
            $(this1).toggleClass("collapseNode expand");
            $(this1).closest('li').find('ul').slideToggle();  
        }
});

//add node btn
$(document).on("click", '.addNode', function (e) {
    e.preventDefault();

    //get value of add node btn
    var getNewName = document.getElementById("nodeName1").value;
    var getNewParent = document.getElementById("parent");

    //validation
    if (getNewName == null || getNewName == "") {
        alert("Nazwa węzła nie może być pusta!");
        return false;
    } else if (getNewName.length > 50 || getNewName.length < 3) {
        alert("Nazwa musi posiadać od 3 do 50 znaków!");
        return false;
    }
    else if (getNewParent.value == null || getNewParent.value == "") {
        alert("Wybierz rodzica dla nowego węzła!");
        return false;
    }

    //send request
    var dataToSend = {
        TreeId: 0,
        TreeName: document.getElementById("nodeName1").value,
        ParentTreeId: getNewParent.options[getNewParent.selectedIndex].getAttribute('pid')
    }

    $.ajax({
        url: "/TreeForm/InsertNode",
        type: "post",
        data: dataToSend,
        success: function (result) {
            if (result == true) {
                updateDiv();
                alert('Sukces');
            } else
                false;
        },
        error: function (xhr, status, error) { alert('Error:' + status + ' ' + error + ' ' + JSON.stringify(dataToSend)); }
    });
});

//move node btn
$(document).on("click", '.moveNode', function (e) {
    e.preventDefault();

    //get value of move node btn
    var getParentID = document.getElementById("currentNodeName").getAttribute('menuId');
    var getNewParent = document.getElementById("newParent");

    //validation
    if (getParentID == null || getParentID == "") {
        alert("Wybierz węzeł, aby go przenieść!");
        return false;
    } else if (getNewParent.value == null || getNewParent.value == "") {
        alert("Wybierz nowego rodzica, aby przenieść węzeł!");
        return false;
    }

    //send request
    var dataToSend = {
        TreeId: getParentID,
        TreeName: "",
        ParentTreeId: getNewParent.options[getNewParent.selectedIndex].getAttribute('pid')
    }

    $.ajax({
        url: "/TreeForm/MoveNode",
        type: "post",
        data: dataToSend,
        success: function (result) {
            if (result == true) {
                updateDiv();
                alert('Sukces');               
            } else
                false;
        },
        error: function (xhr, status, error) { alert('Error:' + status + ' ' + error + ' ' + JSON.stringify(dataToSend)); }
    });

});

//set variables on click for a form
$(document).on("click", '.item', function (e) {
    e.preventDefault();

    var this1 = $(this);  
    if ($(this1).hasClass("item")) {
        var a = $(this1).attr('menuId');
        console.log(a);
        document.getElementById("currentNodeName").value = $(this1).text().trim();
        document.getElementById("currentNodeName").setAttribute('menuId', $(this1).attr('menuId'));
    }   
});

//btn for refresh
$(document).on("click", '.btnRefresh', function (e) {
    e.preventDefault();

    updateDiv();
});

//refresh tree view function
function updateDiv() {
    $(".treeview").load(" .treeview");
    $("#addForm").load(" #addForm");
    $("#moveFrom").load(" #moveFrom");
}
