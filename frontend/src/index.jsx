import React from 'react';
import ReactDOM from 'react-dom';

import 'bootstrap/dist/css/bootstrap.min.css';
import {Container} from 'react-bootstrap';

import App from './App';

ReactDOM.render(
  <React.StrictMode>
    <Container >
      <App />
    </Container>
  </React.StrictMode>,
  document.getElementById('root')
);