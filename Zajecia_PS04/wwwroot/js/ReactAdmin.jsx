
class User extends React.Component {
    render() {
        return (
            <div className="User">
                <h6 className="Id">Id: {this.props.idx}</h6>
                <h6 className="UserName">Nazwa: {this.props.username}</h6>
                <span className="Password">Hasło: {this.props.password}</span>
            </div>
        );
    }
}

class UserList extends React.Component {
    render() {
        const UserNode = this.props.data.map(user => (
            <User username={user.UserName} key={user.Id} idx={user.Id} password={user.password}></User>

        ));
        return <div className="UserList">{UserNode}</div>
    }
}

class UserForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { username:'',password:''};
        this.HandleUserNameChange = this.HandleUserNameChange.bind(this);
        this.HandlePasswordChange = this.HandlePasswordChange.bind(this);
        this.HandleSubmit = this.HandleSubmit.bind(this);
    }

    HandleUserNameChange(x) {
        this.setState({ username: x.target.value });
    }
    HandlePasswordChange(x) {
        this.setState({ password: x.target.value });
    }
    HandleSubmit(x) {
        x.preventDefault();
        const username = this.state.username.trim();
        const password = this.state.password.trim();
        if (!password || !username) {
            return;
        }
        this.props.onUserSubmit({ username: username, password: password });
        this.setState({ password: '', password: '' });

    }
    render() {
        return (
            <form className="UserForm" onSubmit={this.HandleSubmit}>
                <h3>Dodaj użytkownika</h3>
                <input
                    type="text"
                    placeholder="Nazwa użytkownika"
                    value={this.state.username}
                    onChange={this.HandleUserNameChange}
                    className="form-control custom-form-control"
                />
                <input
                    type="text"
                    placeholder="Hasło"
                    value={this.state.password}
                    onChange={this.HandlePasswordChange}
                    className="form-control custom-form-control"
                />
                <input type="submit" className="submitx" value="Dodaj nowego użytkownika" />
                </form>
        );
    }
}

class AdminBox extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
        this.HandleUserSubmit = this.HandleUserSubmit.bind(this);
    }
    LoadDataFromSever() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }
    componentDidMount() {
        this.LoadDataFromSever();
        window.setInterval(
            () => this.LoadDataFromSever(),
            this.props.pollInterval,
        );
    }
    HandleUserSubmit(NewUser) {
        const data = new FormData();
        data.append('UserName', NewUser.username);
        data.append('Password', NewUser.password);

        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.onload = () => this.LoadDataFromSever();
        xhr.send(data);
    }

    render() {
        return (
            <div className="AdminBox">
                <UserList data={this.state.data} />
                <UserForm onUserSubmit={this.HandleUserSubmit} />
            </div>
        );
    }
}

ReactDOM.render(<AdminBox url="/Users" submitUrl="/Users/New" pollInterval={5000} />, document.getElementById("ReactContent"));

