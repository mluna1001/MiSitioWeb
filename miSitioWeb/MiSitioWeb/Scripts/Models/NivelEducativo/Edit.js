const urlController = '/NivelesEducativos/Edit';
const urlGetEditEducationLevel = '/NivelesEducativos/GetEditEducationLevel?EducationLevelId=';

new Vue({
    el: "#MainDiv",
    created: function () {
        this.getData();
    },
    data: function () {
        return { vModel: [] }
    },
    methods: {
        Defaults: function () {
        },
        getData: function () {
            var self = this;
            var url = urlGetEditEducationLevel + EducationLevelId.value
            axios.get(url, {
                dataType: 'json',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                mode: 'no-cors',
                credentials: 'include'
            })
                .then(function (response) {
                    self.vModel = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
        },
        editEducationLevel: function (e) {
            e.preventDefault();
            var self = this;
            var model = { form: self.vModel };

            $.when(saveCadena(urlController, model.form)).then();
        }
    }
});

function saveCadena(url, model) {
    $.ajax({
        type: 'Post',
        dataType: 'html',
        data: model,
        url: url,
        success: function (response) {
            toastr["success"]("Guardado correctamente", "");
            window.location.href = '/NivelesEducativos';
        },
        error: function (response) {
            window.location.href = '/NivelesEducativos';
        }
    });
}