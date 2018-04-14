const urlController = '/AdmPersonalProjects/Create';

new Vue({
    el: "#MainDiv",
    created: function () {

    },
    data: function () {
        return {
            vModel: { PersonalProyectId: "", Project: "", Description: "", PublicationDate: "", PlayStoreURL: "", AppStoreURL:"", WinStoreURL:"", SiteURL: "", Eliminado: ""},
        }
    },
    methods: {
        Defaults: function () {
        },
        createPersonalProject: function (e) {
            e.preventDefault();
            var self = this;
            var model = { form: self.vModel };
            $.when(saveObject(urlController, model.form)).then();
        }
    }
});

function saveObject(url, model) {
    $.ajax({
        type: 'Post',
        dataType: 'json',
        data: model,
        url: url,
        success: function (response) {
            toastr["success"]("Guardado correctamente", "Hecho");
            window.location.href = '/AdmPersonalProjects';
        },
        error: function (response) {
            window.location.href = '/AdmPersonalProjects';
        }
    });
}