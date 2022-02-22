import React, { useState } from 'react'

import { Form } from 'react-bootstrap';

export default function FormField({type, inputName, text, method}) {
  
  const [error, setError] = useState("");

  function verifyInput(){
    if(!text.replace(/\s+/g, '')){
      setError("Please insert a " + inputName.toLowerCase());
    }else{
      setError("");
    }
  }
  
  const errorMessage = error ? <Form.Text className="text-error"> {error} </Form.Text> : null;

  function handleInputChange(event){
    method(event);
    verifyInput();
  }

  return (
    <Form.Group className="mb-3">
      <Form.Label data-testid="label">{inputName}</Form.Label>
      <Form.Control
        data-testid="customInput"
        type={type}
        id={text}
        onChange={handleInputChange}
      />
      { errorMessage }
    </Form.Group>
  )
}
