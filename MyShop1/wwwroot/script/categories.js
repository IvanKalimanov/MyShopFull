function getAllCategories()
{      
    $.ajax(
    {
        type: 'GET',
        url: 'http://localhost:5000/api/category',
        dataType : "json", 
        success: function (data, textStatus)
        { 
            let cat = "";
            data.forEach(function(item)
            {
                cat = cat + category(item.id, item.title);
            });
            $('#category').html(cat);
        } 
    });
    
}; 

function getAllCategoriesInOptions(){
    $.ajax(
        {
            type: 'GET',
            url: 'http://localhost:5000/api/category',
            dataType : "json", 
            success: function (data, textStatus)
            { 
                data.forEach(function (item){

                    $(`<option id="${item.id}" value="${item.title}">${item.title}</option>`).appendTo($('#chooseCat'))
                })
                
            } 
        });
}

function createCategory(title)
{
    $.ajax(
    {
        type: 'POST',
        url: 'http://localhost:5000/api/category',
        dataType : "json",
        contentType: "application/json; charset=utf-8",
        data: `{ "title": "${title}" }`,
        beforeSend: function(request) { // в хедерах передаем токен
            request.setRequestHeader("Authorization", `Bearer ${sessionStorage.getItem("accesstoken")}`);
        },
        success: function (data, textStatus)
        { 
            getAllProducts();
            getAllCategories();
        }, 
        error: function (jqXHR, e){
            if (jqXHR.status == 403)
            alert("Нет достаточных полномочий!(Error 403)")
        }        
    });
};

function deleteCategory(id){
    $.ajax({
        type: 'Delete',
        url: `http://localhost:5000/api/category/${id}`,
        dataType : "json",
        contentType:"application/json; charset=utf-8",
        data: `{"id": "${id}"}`,
        beforeSend: function(request) { // в хедерах передаем токен
            request.setRequestHeader("Authorization", `Bearer ${sessionStorage.getItem("token")}`);
        },
        success: function(data, textStatus){
            getAllProducts();
            getAllCategories();
        },
        error: function (jqXHR, e){
            if (jqXHR.status == 403)
            alert("Нет достаточных полномочий!(Error 403)")
        } 
    })
}

function updateCategory(id, name){
    $.ajax({
        type:'PUT',
        url: `http://localhost:5000/api/category`,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: `{"id": "${id}", "title": "${name}"}`,
        beforeSend: function(request) { // в хедерах передаем токен
            request.setRequestHeader("Authorization", `Bearer ${sessionStorage.getItem("token")}`);
        },
        success: function(data, textStatus){
            getAllProducts();
            getAllCategories();
        },
        error: function (jqXHR, ex){
            if (jqXHR.status == 403)
                alert("Нет достаточных полномочий!(Error 403)")
        } 

    })
}