import { useEffect, useState } from 'react';
import './App.css';

interface Account {
    account_id: number;
    username: string;
    password: string;
    role: string;
}

function App() {
    const [accounts, setAccounts] = useState<Account[] | Account>([]);
    useEffect(() => {
        populateAccountData();
    }, []);

    const renderAccountRow = (account: Account) => (
        <tr key={account.account_id}>
            <td>{account.account_id}</td>
            <td>{account.username}</td>
            <td>{account.password}</td>
            <td>{account.role}</td>
        </tr>
    );

    const contents = Array.isArray(accounts) ? (
        accounts.length === 0 ? (
            <p><em>Loading... Please refresh once the ASP.NET backend has started.</em></p>
        ) : (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Account ID</th>
                        <th>Username</th>
                        <th>Password</th>
                        <th>Role</th>
                    </tr>
                </thead>
                <tbody>
                    {accounts.map(account => renderAccountRow(account))}
                </tbody>
            </table>
        )
    ) : (
        <div>
            <h3>Account Details</h3>
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Account ID</th>
                        <th>Username</th>
                        <th>Password</th>
                        <th>Role</th>
                    </tr>
                </thead>
                <tbody>
                    {renderAccountRow(accounts as Account)}
                </tbody>
            </table>
        </div>
    );

    return (
        <div>
            <h1 id="tableLabel">Account List</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateAccountData() {
        const response = await fetch('/account/find-by-id?id=1');
        const data = await response.json();
        setAccounts(data);
    }
}

export default App;
