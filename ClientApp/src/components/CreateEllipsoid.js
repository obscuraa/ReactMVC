import React, { Component } from 'react';
import axios from 'axios';

export class CreateEllipsoid extends Component {
    constructor(props) {
        super(props)

        this.state = {
            Number: "",
            Rglobal: "",
            FilesNumber: ""
        }

        this.onNumberChange = this.onNumberChange.bind(this);
        this.onRglobalChange = this.onRglobalChange.bind(this);
        this.onFilesNumberChange = this.onFilesNumberChange.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    onXChange(e) {
        this.setState({ Number: e.target.value });
    }

    onYChange(e) {
        this.setState({ Rglobal: e.target.value });
    }

    onZChange(e) {
        this.setState({ FilesNumber: e.target.value });
    }

    onSubmit(e) {
        e.preventDefault();
        var formNumber = this.state.Number;
        var formRglobal = this.state.Rglobal;
        var formFilesNumber = this.state.FilesNumber;
        if (!formNumber || !formRglobal || !formFilesNumber) {
            return;
        }

        var data = new FormData(e.target);

        console.log(formNumber);
        console.log(formRglobal);
        console.log(formFilesNumber);

        data.append("Number", formNumber);
        data.append("Rglobal", formRglobal);
        data.append("FilesNumber", formFilesNumber);

        axios({
            method: 'post',
            url: '/api/Request/CreateRequest/',
            data: data,
        })
            .then((res) => {
                console.log(res);
            })
            .catch((err) => { throw err });

        this.setState({ Number: "", Rglobal: "", FilesNumber: "" });

        axios.get('/api/Request/GetAll')
            .then(response => {
                console.log(response.data);
            })
            .catch(error => {
                console.error(error);
            });

    }

    render() {
        return (
            <>
                <h1>Create Ellipsoid object</h1>

                <div class="row">
                    <div class="col-6">
                        <form id="my-form" onSubmit={this.onSubmit}>
                            <div class="mb-3">
                                <label class="form-label">Enter Number of spheres</label>
                                <input type="number" class="form-control" onChange={this.onNumberChange} />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Enter Rglobal</label>
                                <input type="number" class="form-control" onChange={this.onRglobalChange} />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Enter Number of files</label>
                                <input type="number" class="form-control" onChange={this.onFilesNumberChange} />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Choose bounding area</label>
                                <input type="text" class="form-control" list="exampleList" />
                                <datalist id="exampleList">
                                    <option value="Sphere" />
                                    <option value="Cube" />
                                    <option value="testing" />
                                </datalist>
                            </div>
                            <div>
                                <button type="submit" class="btn btn-primary ">Submit</button>
                            </div>
                        </form>
                    </div>
                </div>
            </>
        )
    }
}
//export class CreateEllipsoid extends Component {
//    render() {
//        return (
//            <>
//                <h1>Create Ellipsoid object</h1>

//                <div class="row">
//                    <div class="col-6">
//                        <form asp-controller="Ellipsoid" asp-action="CreateEllipsoid" method="post">
//                            <div class="mb-3">
//                                <label class="form-label">Enter X coordinate</label>
//                                <input asp-for="X" type="number" class="form-control" />
//                            </div>
//                            <div class="mb-3">
//                                <label class="form-label">Enter Y coordinate</label>
//                                <input asp-for="Y" type="number" class="form-control" />
//                            </div>
//                            <div class="mb-3">
//                                <label class="form-label">Enter Z coordinate</label>
//                                <input asp-for="Z" type="number" class="form-control" />
//                            </div>
//                            <div class="mb-3">
//                                <label class="form-label">Choose bounding area</label>
//                                <input asp-for="BoundingArea" type="text" class="form-control" list="exampleList" />
//                                <datalist id="exampleList">
//                                    <option value="Sphere" />
//                                    <option value="Cube" />
//                                    <option value="testing" />
//                                </datalist>
//                            </div>
//                            <div>
//                                <button type="submit" class="btn btn-primary ">Save</button>
//                            </div>
//                        </form>
//                    </div>
//                </div>
//            </>
//        );
//    }
//}
