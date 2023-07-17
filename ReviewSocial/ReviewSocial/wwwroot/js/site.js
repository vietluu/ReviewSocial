// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const textEditor = document.getElementById("text-editor");
const imageInput = document.getElementById("image-file");

// Image insertion function
async function insertImage(file) {
    while (textEditor.firstChild) {
        textEditor.removeChild(textEditor.firstChild);
    }
    for (let i of file) {
        const reader = new FileReader();
        await reader.readAsDataURL(i);
        reader.onload = async function () {
            const image = new Image();
            image.src = await reader.result;
            await textEditor.appendChild(image);
        };
    }
}

CKEDITOR.replace("content-home");

// Listen for image selection and insert into text editor
imageInput.addEventListener("change", async function (e) {
    const file = e.target.files;
    insertImage(file);
});


function ajaxCustom(url, method, data, successCallback, errorCallback) {
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function() {
      if (xmlhttp.readyState == 4) {
        if (xmlhttp.status == 200) {
          successCallback(xmlhttp.responseText);
        } else {
          errorCallback(xmlhttp.statusText);
        }
      }
    };
    xmlhttp.open(method, url, true);
    xmlhttp.send(data);
}
// cach su dung ->
// ajaxCustom(url, method, data, function(response) {
//     // xử lý kết quả thành công
//   }, function(error) {
//     // xử lý khi có lỗi xảy ra
//   });
