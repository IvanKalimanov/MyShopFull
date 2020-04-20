function category(id, title)
{
    return `<div class="btn btn-outline-info btn-block ctg" id="${id}">
            ${title}
            <button class="deleteCategory" data-id="${id}">&#10008; </button>
            <button class="updateCategory"  data-title="${title}" data-id="${id}">&#9998; </button>
            </div>`;
};

function card(id, name, description, price)
{
    return `<div class="card col-3 mx-4 my-2" style="width:100%" id="${id}">
        <img class="card-img-top mt-2" src="img/photo.jpg" alt="Card image" style="width:100%">
        <div class="card-body"> 
            <h4 class="card-title">${name}</h4>
            <p class="card-text">${description}</p>
            <p class="card-price">${price} руб. </p>
            <button class="deleteProduct" data-id="${id}">	&#10008; </button>
            <button class="updateProduct" data-id="${id}" data-title="${name}"
            data-description="${description}" data-price="${price}">&#9998; </button>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#${id}">
                    Комментарии 
            </button>

            <div class="modal fade" id="${id}" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="staticBackdropLabel">Комментарии к товару</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="card" id="comment-card"></div>
                    <label for="nameOfSender">Отправитель</label>
                    <label for="comment-text">Ваш комментарий</label>
                    <input type="text" id="textOfMsg">
                    <button  class="btn btn-outline-success btn-block " id="sendMsg">Отправить</button>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Understood</button>
                </div>
                </div>
            </div>
            </div>
                    </div>
                </div>`;
    
};

function createCategoryForm()
{
    return `<div class="col-12 text-center">
                <h5>Создать новую категорию</h5>
            </div>
            <div class="col-12">
            <form name="createForm">
                <div class="form-group">
                    <label>Название</label>
                    <input class="form-control" name="title" />
                </div>
            </form>
            <button class="btn btn-outline-success btn-block" id="createCategory">Добавить</button>
            </div`;
}

function updateCategoryForm(id, name)
{
    return `<div class="col-12 text-center">
                <h5>Редактировать категорию</h5>
            </div>
            <div class="col-12">
            <form name="updateCatForm">
                <div class="form-group">
                    <label>Название</label>
                    <input class="form-control" name="title" value="${name}" />
                </div>
            </form>
            <button class="btn btn-outline-success btn-block" data-id="${id}" id="updateCategory">Изменить</button>
            </div`;
}

function createProductForm()
{
    return `<div class="col-12 text-center">
                <h5>Добавить новый товар</h5>
            </div>
            <div class="col-12">
            <form name="createProduct">
                <div class="form-group">
                    <label>Название</label>
                    <input class="form-control" name="title" />
                    <label>Описание</label>
                    <input class="form-control" name="description"/> 
                    <label> Цена </label>
                    <input class="form-control" name="price"/>
                    <label>Категория</label>
                    <select class="form-control" id="chooseCat" name="categoryName">
                        
                    </select>
                </div>
            </form>
            <button class="btn btn-outline-success btn-block" id="createProduct">Добавить</button>
            </div`;
}

function updateProductForm(id, title, description, price)
{
    return `<div class="col-12 text-center">
                <h5>Редактировать товар</h5>
            </div>
            <div class="col-12">
            <form name="updateProduct" ">
                <div class="form-group">
                    <label>Название</label>
                    <input class="form-control" name="title" value="${title}"/>
                    <label>Описание</label>
                    <input class="form-control" name="description" value="${description}"/> 
                    <label> Цена </label>
                    <input class="form-control" name="price" value="${price}"/>
                    <label>Категория</label>
                    <select class="form-control" id="chooseCat" name="categoryName">
                        
                    </select>
                </div>
            </form>
            <button class="btn btn-outline-success btn-block" data-id="${id}" id="updateProduct">Изменить</button>
            </div`;
}

function createCommentsForm(id, title){
    return ``
}

