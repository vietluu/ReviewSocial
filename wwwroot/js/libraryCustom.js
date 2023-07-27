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

const imagePreview = document.getElementById("imagePreview");
const imageIn = document.getElementById("file");
async function preview(file) {
    while (imagePreview?.firstChild) {
        imagePreview.removeChild(imagePreview.firstChild);
    }
    for (let i of file) {
        const reader = new FileReader();
        await reader.readAsDataURL(i);
        reader.onload = async function () {
            const image = new Image();
            image.src = await reader.result;
            await imagePreview.appendChild(image);
        };
    }
}
imageIn.addEventListener("change", async function (e) {
    const file = e.target.files;
    preview(file);
}
  
)
const imagePreview2 = document.getElementById("imagePreview2");
const imageIn2 = document.getElementById("file2");
async function preview2(file) {
    while (imagePreview2?.firstChild) {
        imagePreview2.removeChild(imagePreview2.firstChild);
    }
    for (let i of file) {
        const reader = new FileReader();
        await reader.readAsDataURL(i);
        reader.onload = async function () {
            const image = new Image();
            image.src = await reader.result;
            await imagePreview2.appendChild(image);
        };
    }
}
imageIn2?.addEventListener("change", async function (e) {
    const file = e.target.files;
    preview2(file);
}
)



