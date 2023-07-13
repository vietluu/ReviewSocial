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