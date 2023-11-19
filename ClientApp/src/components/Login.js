import React, { Component } from 'react';
import axios from 'axios';

export class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            user: { userEmail: '', userPassword: '' }
        };
        this.apiUrl = "http://localhost:7077/api/Account/login";
    }

    Login = (e) => {
        e.preventDefault();
        debugger;
        const data = { Email: this.state.user.Email, Password: this.state.user.Password };
        axios.post(this.apiUrl, data)
            .then((result) => {
                debugger;
                console.log(result.data);
                const serializedState = JSON.stringify(result.data.UserDetails);
                var a = localStorage.setItem('myData', serializedState);
                console.log("A:", a)
                const userData = result.data.UserDetails;
                console.log(result.data.message);
                if (result.data.status === '200')
                    this.props.history.push('/');
                else
                    alert('Invalid User');
            });
    };

    onChange = (e) => {
        e.persist();
        debugger;
        this.setState(prevState => ({
            user: { ...prevState.user, [e.target.name]: e.target.value }
        }));
    }

    render() {
        return (
<div className="container">
    <div className="row justify-content-center">
        <div className="col-xl-10 col-lg-12 col-md-9">
            <div className="card o-hidden border-0 shadow-lg my-5">
                <div className="card-body p-0">
                    <div className="row">
                        <div className="col-lg-6 d-none"></div>
                        <div className="col-lg-6">
                            <div className="p-5">
                                <div className="text-center">
                                    <h1 className="h4 text-gray-900 mb-4">Login</h1>
                                </div>
                                <form onSubmit={this.Login} className="userData">
                                    <div className="form-group">
                                        <input type="email" className="form-control" value={this.state.user.Email} onChange={this.onChange} name="Email" id="Email" aria-describedby="emailHelp" placeholder="Enter Email" />
                                    </div>
                                    <div className="form-group">
                                        <input type="password" className="form-control" value={this.state.user.Password} onChange={this.onChange} name="Password" id="DepPasswordartment" placeholder="Password" />
                                    </div>
                                    <button type="submit" className="btn btn-primary mb-2" block>Login</button>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
        );
    }
}
