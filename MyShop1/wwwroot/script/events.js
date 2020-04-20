$('#all').click(getAllProducts);

$("#category").delegate(".ctg", "click", function (e) {
    getProductsByCategory(e.target.id);
});

$('#newCtg').click(function () {
    $('#content').html(createCategoryForm());
});

$('#newProd').click(function () {
    $('#content').html(createProductForm());
    getAllCategoriesInOptions();
})

$('#content').delegate('#createProduct', 'click', function () {

    let a = document.forms.createProduct.categoryName.value
    let b = ""
    for (var i = 1;
        i < document.forms.createProduct.categoryName.childNodes.length && b == ""; i++) {
        if (document.forms.createProduct.categoryName.childNodes[i].value == a)
            b = document.forms.createProduct.categoryName.childNodes[i].id;
    }

    createProduct(document.forms.createProduct.title.value,
        document.forms.createProduct.description.value,
        document.forms.createProduct.price.value,
        b
    )
});

$('#content').delegate("#createCategory", "click", function () {
    createCategory(document.forms.createForm.title.value);
});

$('#content').delegate(".deleteProduct", "click", function () {
    deleteProduct(this.getAttribute('data-id'));
})

$('#category').delegate(".deleteCategory", "click", function () {
    deleteCategory(this.getAttribute('data-id'));
})

$('#category').delegate(".updateCategory", "click", function (e) {
    $('#content').html(updateCategoryForm(this.getAttribute('data-id'), this.getAttribute('data-title')))
})

$('#content').delegate("#updateCategory", "click", function () {
    updateCategory(this.getAttribute('data-id'), document.forms.updateCatForm.title.value)
})

$('#content').delegate(".updateProduct", "click", function () {
    $('#content').html(updateProductForm(this.getAttribute('data-id'),
        this.getAttribute('data-title'), this.getAttribute('data-description'), this.getAttribute('data-price')))
    getAllCategoriesInOptions();
})
$('#exit').click(function () {
    console.log("exit");
    sessionStorage.removeItem("token");
    document.location.href = "https://localhost:5000/login.html";
})

$('#content').delegate("#updateProduct", "click", function () {
    let a = document.forms.updateProduct.categoryName.value
    let b = ""
    for (var i = 1;
        i < document.forms.updateProduct.categoryName.childNodes.length && b == ""; i++) {
        if (document.forms.updateProduct.categoryName.childNodes[i].value == a)
            b = document.forms.updateProduct.categoryName.childNodes[i].id;
    }
    console.log(this.getAttribute('data-id'), document.forms.updateProduct.title.value,
        document.forms.updateProduct.description.value, document.forms.updateProduct.price.value, b)
    updateProduct(this.getAttribute('data-id'), document.forms.updateProduct.title.value,
        document.forms.updateProduct.description.value, document.forms.updateProduct.price.value, b)
})
