const urlController = '/AdmEducations/Edit';
const urlEducationLevel = '/AdmEducations/GetDataEducationLevel'
const urlGetEditEducation = '/AdmEducations/GetEditEducation?EducationId=';

new Vue({
    el: "#MainDiv",
    created: function () {
        this.getData();
        this.getEducationLevel();
    },
    computed: {
        vTargetType: function () {
            if (this.vModel.EducationLevelId != "") {
                for (var i = 0, l = this.vEducationLevel.length; i < l; i++) {
                    if (this.vEducationLevel[i].EducationLevelId == this.vModel.EducationLevelId) {
                        this.vModel.TargetType = this.vEducationLevel[i].TargetType;
                    }
                }
            }
        }
    },
    data: function () {
        return {
            vEducationLevel: [],
            vModel: [],
        }
    },
    methods: {
        Defaults: function () {
        },
        getData: function () {
            var self = this;
            var url = urlGetEditEducation + EducationId.value;
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
        getEducationLevel: function () {
            var self = this;
            axios.get(urlEducationLevel)
                .then(function (response) {
                    self.vEducationLevel = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
        },
        editEducation: function (e) {
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
            window.location.href = '/AdmEducations';
        },
        error: function (response) {
            window.location.href = '/AdmEducations';
        }
    });
}