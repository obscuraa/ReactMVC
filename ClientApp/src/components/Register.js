import React, { Component } from 'react';
import axios from 'axios';

export class Register extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: { userEmail: '', userPassword: '', uniqueUsername: '', firstName: '', lastName: '', idInteger: '', roles: [] }
        };
        this.apiUrl = "http://localhost:7077/api/Account/register";
    }

    Registration = (e) => {
        e.preventDefault();
        debugger;
        const data1 = { userEmail: this.state.data.Email, userPassword: this.state.data.Password };
        axios.post(this.apiUrl, data1)
            .then((result) => {
                debugger;
                console.log(result.data);
                if (result.data.statusCode === 500)
                    alert('Invalid User');
                else
                    this.props.history.push('/');
            });
    }

    onChange = (e) => {
        e.persist();
        debugger;
        this.setState(prevState => ({
            data: { ...prevState.data, [e.target.name]: e.target.value }
        }));
    }

    render() {
        return (
            <div className="container">
                <div className="card o-hidden border-0 shadow-lg my-5" style={{ "marginTop": "5rem!important" }}>
                    <div className="card-body p-0">
                        <div className="row">
                            <div className="col-lg-12">
                                <div className="p-5">
                                    <div className="text-center">
                                        <h1 className="h4 text-gray-900 mb-4">Create new user</h1>
                                    </div>
                                    <form onSubmit={this.Registration} className="user">
                                        <div className="form-group row">
                                            <div className="col-sm-6 mb-3 mb-sm-0">
                                                <input type="text" name="Email" onChange={this.onChange} value={this.state.data.Email} className="form-control" id="exampleFirstName" placeholder="Email" />
                                            </div>
                                            <div className="col-sm-6">
                                                <input type="Password" name="Password" onChange={this.onChange} value={this.state.data.Password} className="form-control" id="exampleLastName" placeholder="Password" />
                                            </div>
                                        </div>
                                        <button type="submit" className="btn btn-primary btn-block">
                                            Create user
                                        </button>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
