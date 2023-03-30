
$(document).ready(function () {
    $.ajax({
        type: 'Get',
        url: 'https://localhost:44330/api/homeapi',
        datatype: 'json',
        success: function (response) {
            response.forEach((user, index) => {
                let html =
                    `<tr>
                        <td><img src="../Images/${user.imagePath}" /></td>
                        <td>${user.Kind}</td>
                        <td>${user.treeNameId}</td>
                        <td>${user.diseaseId}</td>
                        <td>
                            <a href="../Home/Edit/${user.Id}" class="btn btn-primary">Detay</a>
                        </td>
                    </tr>`;
                $("#bodyItem").append(html);
            })
        }
    })
})
    //$(function () {
    //    window.onload = (function () {
    //        $.ajax({
    //            type: 'Get',
    //            url: 'https://localhost:44330/api/homeapi',
    //            datatype: 'json',
    //            success: function (response) {
    //                response.forEach((user, index) => {
    //                    let html =
    //                        `<tr>
    //                            <td>${user.Id}</td>
    //                            <td>${user.imagePath}</td>
    //                            <td>${user.Kind}</td>
    //                            <td>${user.treeNameId}</td>
    //                            <td>${user.diseaseId}</td>
    //                            <td>
    //                                <button type="button" class="btn btn-primary">Detay</button>
    //                            </td>
    //                        </tr>`;

    //                    $("#bodyItem").append(html);
    //                })
    //            }
    //        })
    //    })
    //})