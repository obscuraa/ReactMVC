import React, { Component } from 'react';
import axios from 'axios';

export class CreateEllipsoid extends Component {
    constructor(props) {
        super(props)

        this.state = {
            X: "",
            Y: "",
            Z: ""
        }

        this.onXChange = this.onXChange.bind(this);
        this.onYChange = this.onYChange.bind(this);
        this.onZChange = this.onZChange.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    onXChange(e) {
        this.setState({ name: e.target.value });
    }

    onYChange(e) {
        this.setState({ email: e.target.value });
    }

    onZChange(e) {
        this.setState({ text: e.target.value });
    }

    onSubmit(e) {
        e.preventDefault();
        var formX = this.state.X;
        var formY = this.state.Y;
        var formZ = this.state.Z;
        if (!formX || !formY || !formZ) {
            return;
        }

        var data = new FormData(e.target);

        console.log(formX);
        console.log(formY);
        console.log(formZ);

        data.append("X", formX);
        data.append("Y", formY);
        data.append("Z", formX);

        axios({
            method: 'post',
            url: '/api/Requst/CreateRequest/',
            data: data,
        })
            .then((res) => {
                console.log(res);
            })
            .catch((err) => { throw err });

        this.setState({ X: "", Y: "", Z: "" });

        axios.get('/api/request')
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
                                <label class="form-label">Enter X coordinate</label>
                                <input type="number" class="form-control" onChange={this.onXChange} />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Enter Y coordinate</label>
                                <input type="number" class="form-control" onChange={this.onYChange} />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Enter Z coordinate</label>
                                <input type="number" class="form-control" onChange={this.onZChange} />
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
