const urlController = '/AdmScholarshipProjects/Edit';
const urlGetEditScholarshipProject = '/AdmScholarshipProjects/GetEditScholarshipProject?ProjectId=';

new Vue({
    el: "#MainDiv",
    created: function () {
        this.getData();
    },
    data: function () {
        return {
            vModel: [],
        }
    },
    methods: {
        Defaults: function () {
        },
        getData: function () {
            var self = this;
            var url = urlGetEditScholarshipProject + ProjectId.value
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
        editScholarshipProject: function (e) {
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
            window.location.href = '/AdmScholarshipProjects?EducationId=' + model.EducationId;
        },
        error: function (response) {
            window.location.href = '/AdmScholarshipProjects?EducationId=' + model.EducationId;
        }
    });
}