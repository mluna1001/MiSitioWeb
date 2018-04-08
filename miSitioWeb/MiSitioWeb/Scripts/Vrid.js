(function () {

    function install(Vue) {

        var util = {};

        util.paginationData = {};

        util.getPaginationData = function (id) {
            if (util.paginationData.hasOwnProperty(id)) {
                return util.paginationData[id];
            }
            return util.paginationData[id] = {
                page: 0,
                pageCount: 0
            };
        };

        Vue.component('grid', {
            replace: true,
            template: `
            <div class="table-responsive">
                 
                <table class="table table-bordered table-striped table-condensed table-sm">
                    <thead>
                        <tr>
                            <th v-for="col in columns" v-on:click="sortBy(col)" >
                                <div>{{col}}</div>
                                <div class="arrow" v-if="col == sortColumn" v-bind:class="[ascending ? 'arrow_up' : 'arrow_down']" ></div>
                            </th>
                            <th>
                                Acci&oacute;n
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="row in get_rows()">
                            <td v-for="col in columns">
                                <span>{{row[col]}}</span>
                            </td>
                            <td>
                                <button v-on:click="editElement(row)" class="btn btn-outline-success">
                                    <i class="fa fa-edit"></i>
                                    Editar
                                </button>
                                <button type="button" data-toggle="modal" data-target="#deleteModal" class="btn btn-outline-danger" v-on:click="confirmDelete(row)">
                                    <i class="fa fa-trash-o"></i>
                                    Eliminar
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <nav>
                    <ul class="pagination">
                        <li v-for="i in num_pages()" v-bind:class="[i == currentPage ? 'page-item active' : 'page-item']" v-on:click="change_page(i)">
                            <a class="page-link" href="#">{{i}}</a>
                        </li>
                    </ul>
                </nav>

                        
            </div>
            
            `,
            props: ['columna', 'rows', 'filter-key'],
            data: function () {

                return {
                    currentPage: 1,
                    elementsPerPage: 10,
                    ascending: false,
                    sortColumn: '',
                    itemToDelete: null
                };
            },
            computed: {
                columns: function () {
                    var col = this.columna;
                    return col;
                }
            },
            compiled: function () {

            },
            methods: {
                sortBy: function (col) {
                    if (this.sortColumn === col) {
                        this.ascending = !this.ascending;
                    } else {
                        this.ascending = true;
                        this.sortColumn = col;
                    }

                    var ascending = this.ascending;

                    this.ascending = ascending;

                    this.rows.sort(function (a, b) {
                        if (a[col] > b[col]) {
                            return ascending ? 1 : -1
                        } else if (a[col] < b[col]) {
                            return ascending ? -1 : 1
                        }
                        return 0;
                    })
                },
                num_pages: function () {
                    return Math.ceil(this.rows.length / this.elementsPerPage);
                },
                get_rows: function () {
                    var start = (this.currentPage - 1) * this.elementsPerPage;
                    var end = start + this.elementsPerPage;
                    return this.rows.slice(start, end);
                },
                change_page: function (page) {
                    this.currentPage = page;
                },
                editElement: function (item) {
                    var locationEdit = LocationEdit.value
                    window.location.href = locationEdit + item.KeyId;
                },
                editElementModule: function (item) {
                    var locationCreateIdModule = LocationCreateIdModule.value
                    window.location.href = locationCreateIdModule + item.IdKey;
                },
                confirmDelete: function (item) {
                    this.$parent.itemToDelete = item;
                },
                confirmBloquear: function (item) {
                    this.$parent.itemToDelete = item;
                },
                seleccionar: function (item) {
                    var seleccionarCliente = SeleccionarCliente.value
                    window.location.href = seleccionarCliente + item.IdKey;
                },
                select: function (item) {
                    var selection = Select.value
                    window.location.href = selection + item.IdKey;
                },
            }
        });
    }

    if (typeof exports == "object") {
        module.exports = install;
    } else if (typeof define == "function" && define.amd) {
        define([], function () { return install });
    } else if (window.Vue) {
        Vue.use(install);
    }

})();
