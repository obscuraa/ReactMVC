class Request extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.request };
        this.onClick = this.onClick.bind(this);
    }
    onClick(e) {
        this.props.onRemove(this.state.data);
    }
    render() {
        return <div>
            <p>X coordinate {this.state.data.X}</p>
            <p>Y coordinate {this.state.data.Y}</p>
            <p>Z coordinate {this.state.data.Z}</p>
            <p>Radius {this.state.data.Radius}</p>
            <p>Number {this.state.data.Radius}</p>
            <p>Rglobal {this.state.data.Radius}</p>
            <p>FilesNumber {this.state.data.Radius}</p>

            <p><button onClick={this.onClick}>Create</button></p>
        </div>;
    }
}

class RequestForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = { X: 0, Y: 0, Z: 0, radius: 0, number: 0, rglobal: 0, filesnumber: 0 };

        this.onSubmit = this.onSubmit.bind(this);
    }

    onXChange(e) {
        this.setState({ X: e.target.value });
    }
    onYChange(e) {
        this.setState({ Y: e.target.value });
    }
    onZChange(e) {
        this.setState({ Z: e.target.value });
    }
    onRadiusChange(e) {
        this.setState({ radius: e.target.value });
    }
    onNumberChange(e) {
        this.setState({ number: e.target.value });
    }
    onRglobalChange(e) {
        this.setState({ rglobal: e.target.value });
    }
    onFilesnumberChange(e) {
        this.setState({ filesnumber: e.target.value });
    }

    onSubmit(e) {
        e.preventDefault();
        var formX = this.state.X;
        var formY = this.state.Y;
        var formZ = this.state.Z;
        var formRadius = this.state.radius;
        var formNumber = this.state.number;
        var formRglobal = this.state.rglobal;
        var formFilesnumber = this.state.filesnumber;

        //if (!phoneName || phonePrice <= 0) {
        //    return;
        //}

        this.props.onRequestSubmit({ X: formX, Y: formY, Z: formZ, radius: formRadius, number: formNumber, rglobal: formRglobal, filesnumber: formFilesnumber });
        // эта строчка скорее не нужна
        //this.setState({ name: "", price: 0 });
    }
    render() {
        return (
            <form onSubmit={this.onSubmit}>
                <p>
                    <input type="number"
                        placeholder="X"
                        value={this.state.X}
                        onChange={this.onXChange} />
                </p>
                <p>
                    <input type="number"
                        placeholder="Y"
                        value={this.state.Y}
                        onChange={this.onYChange} />
                </p>
                <p>
                    <input type="number"
                        placeholder="Z"
                        value={this.state.Z}
                        onChange={this.onZChange} />
                </p>
                <p>
                    <input type="number"
                        placeholder="Radius"
                        value={this.state.radius}
                        onChange={this.onRadiusChange} />
                </p>
                <p>
                    <input type="number"
                        placeholder="Number"
                        value={this.state.number}
                        onChange={this.onNumberChange} />
                </p>
                <p>
                    <input type="number"
                        placeholder="Rglobal"
                        value={this.state.rglobal}
                        onChange={this.onRglobalChange} />
                </p>
                <p>
                    <input type="number"
                        placeholder="Files number"
                        value={this.state.filesnumber}
                        onChange={this.onFilesnumberChange} />
                </p>
                <input type="submit" value="Save" />
            </form>
        );
    }
}

class PhonesList extends React.Component {
    constructor(props) {
        super(props);
        this.state = { requests: [] };

        this.onAddPhone = this.onAddPhone.bind(this);
        this.onRemovePhone = this.onRemovePhone.bind(this);
    }
    // загрузка данных
    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ requests: data });
        }.bind(this);
        xhr.send();
    }
    componentDidMount() {
        this.loadData();
    }
    // добавление объекта
    onAddRequest(request) {
        if (request) {

            const data = new FormData();
            data.append("X", request.X);
            data.append("Y", request.Y);
            data.append("Z", request.Z);
            data.append("Radius", request.radius);
            data.append("Number", request.number);
            data.append("Rglobal", request.rglobal);
            data.append("Filesnumber", request.filesnumber);
            var xhr = new XMLHttpRequest();

            xhr.open("post", this.props.apiUrl, true);
            xhr.onload = function () {
                if (xhr.status === 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send(data);
        }
    }
    render() {
        return <div>
            <RequestForm onRequestSubmit={this.onAddRequest} />
            <h2>Список</h2>
            <div>
                {
                    this.state.requests.map(function (request) {
                        return <Request key={request.X} request={request} />
                    })
                }
            </div>
        </div>;
    }
}

ReactDOM.render(
    <PhonesList apiUrl="/api/request" />,
    document.getElementById("root")
);