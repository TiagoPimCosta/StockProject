import React from "react";

import { Col, InputGroup, FormControl } from "react-bootstrap";

export default function Filters({ changeMethod }) {
  return (
    <Col>
      <InputGroup className="mb-3">
        <InputGroup.Text id="inputGroup-sizing-default">Name</InputGroup.Text>
        <FormControl
          aria-label="Default"
          aria-describedby="inputGroup-sizing-default"
          onChange={(event) => changeMethod(event.target.value)}
        />
      </InputGroup>
    </Col>
  );
}
