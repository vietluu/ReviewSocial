const url = "/Post/";
const request = new XMLHttpRequest();
const btnSubmit = document.getElementById("btnSubmit");
const btnCloseModal = document.getElementById("btnCloseModal");
const listPost = document.getElementById("listPost");

btnSubmit.onclick = checkUpdate;

function checkUpdate() {
    if (btnSubmit.value != "add")
        update();
    else
        create();
}

function create() {
    var check = true;
    if (document.getElementById("title").value == "") {
        document.getElementById("error-title").innerHTML = "Tiêu đề không được trống";
        check = false;
    }
    //else if (document.getElementById("title").value.length > 10) {
    //    document.getElementById("error-title").innerHTML = "Tiêu đề không được quá 10 ký tự";
    //    check = false;
    //}
    else {
        document.getElementById("error-title").innerHTML = "";
    }

    if (CKEDITOR.instances["content-home"].getData() == "") {
        document.getElementById("error-content").innerHTML = "Nội dung không được trống";
        check = false;
    }
    else {
        document.getElementById("error-content").innerHTML = "";
    }

    //if (document.getElementById("file").value == "") {
    //    document.getElementById("error-file").innerHTML = "Vui lòng chọn ảnh bài viết";
    //    check = false;
    //} else {
    //    document.getElementById("error-file").innerHTML = "";
    //}

    if (!check) {
        return;
    }

    var post = getDataForm();
    console.log(post);
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var res = JSON.parse(this.responseText);
            console.log(res);
            if (res.message != null) {
                //error.innerHTML = res.message;
                document.getElementById("error-title").innerHTML = res.message;
                return;
            }
         
            listPost.insertAdjacentHTML("afterbegin", renderPost(res));
            btnCloseModal.click();
            alert("Thêm bài viết thành công");
            resetForm();
        }
    };
    request.open("POST", url + "Create", true);
    //request.setRequestHeader("Content-type", "application/json");
    //request.send(JSON.stringify(post));
    request.send(post);
}

function getDataForm() {
    var formData = new FormData();
    formData.append("Title", document.getElementById("title").value);
    formData.append("Content", CKEDITOR.instances["content-home"].getData());
    formData.append("CategoryId", document.getElementById("category").value);
    formData.append("file", document.getElementById("file").files[0] || "");
    return formData;
}

function resetForm() {
    document.getElementById("title").value = "";
    CKEDITOR.instances["content-home"].setData("");
    //document.getElementById("subCategory").value = "";
    document.getElementById("file").value = null;
    document.getElementById("exampleModalLabel").innerText = "Thêm thông tin bài viết";
    document.getElementById("btnSubmit").value = "add";
    document.getElementById("btnSubmit").innerText = "Lưu";
    document.getElementById("btnCloseModal").click();
}

function renderPost(post) {
    const nameCategory = getCategoryNameByCategoryId(post.CategoryId);

    return `<div class="panel panel-default mb-3 bg-white p-2 rounded-3" id="post-${post.id}">
                        <div class="panel-heading">
                            <img src="${post.user.avatar == null ? "/img/avatar.jpg" : "/img/" + post.user.avatar}" class="img-rounded img-circle">
                            <div class="pull-right text-right">
                                <div class="dropdown">
                                    <button class="btn btn-secondary bg-transparent text-dark border-0" type="button" data-toggle="dropdown" aria-expanded="false">
                                        <i class="fa fa-ellipsis-h"></i>
                                    </button>
                                    <div class="dropdown-menu" style="margin-left: -155px;">
                                        <a class="dropdown-item" href="#" data-toggle="modal" data-target="#exampleModal" onclick="getPostById(${post.id})"><i class="fa fa-pencil" aria-hidden="true"></i> Chỉnh sửa bài viết</a>
                                        <a class="dropdown-item" href="#" data-toggle="modal" data-target="#deletePostModal" onclick="getPostId(${post.id})"><i class="fa fa-trash" aria-hidden="true"></i> Xóa bài</a>
                                        <a class="dropdown-item" href="#"><i class="fa fa-window-close" aria-hidden="true"></i> Ẩn bài viết</a>
                                    </div>
                                </div>
                            </div>
                            <div><strong>${post.user.username}</strong></div>
                        </div>
                        <div class="panel-body">
                            <div class="text-center">
                                <a href="/post/details/${post.id}">
                                    <img src="${post.thumbnail == null ? "/img/logo.jpg" : "/img/posts/" + post.thumbnail}" class="img-responsive w-50">
                                </a>

                            </div>
                            <div class="card-body text-center">
                                <a href="/post/details/${post.id}" class="card-text" id="title-${post.id}">${post.title}</a>
                            </div>
                            <div class="actions">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-link"><i class="fa fa-thumbs-o-up"></i> Like</button>
                                    <button type="button" class="btn btn-link"><i class="fa fa-comments"></i> Comment</button>
                                </div>
                                <div class="pull-right"><strong>${post.view}</strong> People View this</div>
                            </div>
                        </div>
                    </div>`;
}

function getCategoryNameByCategoryId(CategoryId) {
    var select = document.getElementById("category");
    for (var i = 0; i < select.options.length; i++) {
        var option = select.options[i];
        if (option.value == CategoryId) {
            return option.innerHTML;
        }
    }
    return "";
}

// xoa bài viết trang chủ
function getPostId(id) {
    document.getElementById("btnDeletePost").value = id;
}

function deletePostWithModal() {
    var id = document.getElementById("btnDeletePost").value;
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            const id = this.responseText;
            document.getElementById("post-" + id).style.display = "none";
            document.getElementById("btnCloseModalDelete").click();
            alert("Xóa bài viết thành công");
        }
    };
    request.open("POST", url + "Delete", true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.send("id=" + id);
}
// sửa bài viết trang chủ
function getPostById(id) {
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            const { id, title, content, categoryId } = JSON.parse(
                this.responseText
            );
            document.getElementById("title").value = title;
            CKEDITOR.instances["content-home"].setData(content);
            document.getElementById("category").value = categoryId;
            btnSubmit.value = id;
            btnSubmit.innerText = "Cập nhật"
        }
    };

    request.open("GET", url + "GetPostById?id=" + id, true);
    request.send();
}
function update() {
    var post = getDataForm();
    post.append("Id", btnSubmit.value);
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var res = JSON.parse(this.responseText);
            if (res.message != null) {
                error.innerHTML = res.message;
                return;
            }

            document.getElementById(`title-${res.id}`).innerText = res.title;
            if (document.getElementById(`content-${res.id}`) != null) {
                document.getElementById(`content-${res.id}`).innerHTML = res.content;
            }


            //document.getElementById(post - ${ res.id }).children[3].innerText = getSubCategoryNameBySubCategoryId(res.subCategoryId);
            if (document.getElementById(`thumbnail-${res.id}`) != null) {
                document.getElementById(`thumbnail-${res.id}`).innerHTML =
                    `<img src="${res.thumbnail != null ? "/img/posts/" + res.thumbnail : "/img/logo.jpg"}" class="img-responsive w-50">`;
            }


            alert("Cập nhật bài viết thành công!");
            //resetForm();
            document.getElementById("btnCloseModal").click();
        }
    };
    request.open("POST", url + "Update", true);
    request.send(post);
}

function hidenPost(id) {
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("post-" + id).style.display = "none";
            alert("Ẩn bài viết thành công");
        }
    };
    request.open("POST", url + "HidenPost", true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.send("id=" + id);
}
