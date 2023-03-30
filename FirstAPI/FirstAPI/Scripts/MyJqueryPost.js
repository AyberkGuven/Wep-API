
function createDetail() {
    var url = "https://localhost:44330/api/homeapi";

    var Id = $('#Id').val();
    var Kind = $('#Kind').val();
    var treeNameId = $('#Name').val();
    var diseaseId = $('#Disease').val();
    var imagePath = $('#Image').val();
    var Description = $('#Description').val();

    var Detail = {};

    if (Id === '' || Kind === '' || treeNameId === '' || diseaseId === '' ||
        imagePath === '' || Description === '') {
        alert('Boş Nesne');
    } else {
        Detail.Id = Id;
        Detail.Kind = Kind;
        Detail.treeNameId = treeNameId;
        Detail.diseaseId = diseaseId;
        Detail.imagePath = imagePath;
        Detail.Description = Description;

        //console.log(Detail); //veri geldi.

        if (Detail) {
            $.ajax({
                url: url,
                type: "Post",
                data: Detail,
                dataType: "json",
                success: function (data) {
                    clearForm();
                    /*window.location.href = "Index";*/
                },
                error: function () {
                    alert('Neden olmuyorsun...');
                }
            })
        }
    }
}

function clearForm() {
    $('#Id').val('');
    $('#Kind').val('');
    $('#Name').val('');
    $('#Disease').val('');
    $('#Image').val('');
    $('#Description').val('');
}