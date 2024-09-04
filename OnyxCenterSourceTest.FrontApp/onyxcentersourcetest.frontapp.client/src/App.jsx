import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [vatStatus, setVatStatus] = useState('');
    const [countryCode, setCountryCode] = useState('');
    const [vatId, setVatId] = useState('');


    return (
        <div>
            <h1 id="tableLabel">Vat Validation</h1>
            <p>This component provides vat validation.</p>
            <div>
                <div>
                    <label>
                        Country code: <input name="countryCode" value={countryCode} onChange={e => setCountryCode(e.target.value)} />
                    </label>
                    <label>
                        Vat ID: <input name="vatId" type="number" value={vatId} onChange={e => setVatId(e.target.value)} />
                    </label>
                </div>
                <button onClick={() => { checkVat(); }}>
                    Validate
                </button>
            </div>
            <div>{vatStatus}</div>
        </div>
    );

    async function checkVat() {
        if (!countryCode || !vatId) {
            setVatStatus('Please enter data');
            return;
        }
        const response = await fetch('vatverify/' + countryCode + '/' + vatId);
        console.log(response);
        const data = await response.text();
        setVatStatus('Status of ' + countryCode + vatId+ ': ' + data);
    }
}

export default App;