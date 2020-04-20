function getAllProducts()
{   
    $.ajax(
    {
        type: 'GET',
        url: 'http://localhost:5000/api/product',
        dataType : "json", 
        success: function (data, textStatus)
        { 
            let products = "";
            data.forEach(function(item)
            {
                products = products + card(item.id, item.name, item.description, item.price);
            });
            $('#content').html(products);
        } 
    });
};

function getProductsByCategory(id)
{
    $.ajax(
    {
        type: 'GET',
        url: `http://localhost:5000/api/product/category/${id}`,
        dataType : "json", 
        success: function (data, textStatus)
        { 
            let products = "";
            data.forEach(function(item)
            {
                products = products + card(item.id, item.name, item.description, item.price);
            });
            $('#content').html(products);
        } 
    });
};

function createProduct(name, description, price, categoryId){
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5000/api/product',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: `{"name": "${name}", "description": "${description}",
         "price": ${parseInt(price)}, "categoryId": "${categoryId}"}`,
         beforeSend: function(request) { // в хедерах передаем токен
            request.setRequestHeader("Authorization", `Bearer ${sessionStorage.getItem("token")}`);
        },
        success: function(data, textStatus){
            getAllProducts();
            getAllCategories();
        },
        error(jqXHR, ex){
            if (jqXHR.status == 403)
                alert("Нет достаточных полномочий!(Error 403)")
        }
    })
}

function deleteProduct(id){
    $.ajax({
        type: 'Delete',
        url: `http://localhost:5000/api/product/${id}`,
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
        error(jqXHR, ex){
            if (jqXHR.status == 403)
                alert("Нет достаточных полномочий!(Error 403)")
        }
    })
}

function updateProduct(id, name, description, price, categoryId){
    $.ajax({
        method: 'Put',
        url: `http://localhost:5000/api/product`,
        dataType : "json",
        contentType:"application/json; charset=utf-8",
        data: `{"id": "${id}", "name": "${name}", "price":${parseInt(price)}, 
        "description":"${description}", "categoryId":"${categoryId}"}`,
        beforeSend: function(request) { // в хедерах передаем токен
            request.setRequestHeader("Authorization", `Bearer ${sessionStorage.getItem("token")}`);
        },
        success: function(data, textStatus){
            getAllProducts();
            getAllCategories();
        },
        error(jqXHR, ex){
            if (jqXHR.status == 403)
                alert("Нет достаточных полномочий!(Error 403)")
        }
    })
}