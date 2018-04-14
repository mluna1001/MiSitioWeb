const urlController = '/AdmWorks/Create';

new Vue({
    el: "#MainDiv",
    created: function () {
        
    },
    computed: {
        
    },
    data: function () {
        return {
            vWorkExperience: [],
            vModel: { WorkExperienceId: "", StartDate: "", EndDate: "", Organization: "", Job: "", Description: "", State: "", Town: "", Country: "" },
        }
    },
    methods: {
        Defaults: function () {
        },
        createWorkExperience: function (e) {
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
            window.location.href = '/AdmWorks';
        },
        error: function (response) {
            window.location.href = '/AdmWorks';
        }
    });
}