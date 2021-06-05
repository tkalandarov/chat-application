// Auto size for textarea
function resizeTextarea() {
    $('textarea').each(function () {
        this.setAttribute('style', 'height:' + (this.scrollHeight) + 20 + 'px;overflow-y:hidden;');
    }).on('input', function () {
        if (this.value != '') {
            this.style.height = 'auto';
            this.style.height = (this.scrollHeight) - 20 + 'px';
        }
        else {
            this.style.height = '20px';
        }
    });
}
$(document).ready(function () {
    resizeTextarea();
});