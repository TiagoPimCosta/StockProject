import { render } from "@testing-library/react";
import FormField from "../../components/FormField";

describe("FormField", () => {
  it("Label correct value", () => {
    const { getByTestId } = render(<FormField inputName={"Name"} />);
    const label = getByTestId("label");
    expect(label.textContent).toBe("Name");
  });

  it("Input correct type", () => {
    const { getByTestId } = render(<FormField type={"text"} />);
    const input = getByTestId("customInput");
    expect(input).toHaveProperty("type", "text");
  });

  it("Input correct id", () => {
    const { getByTestId } = render(<FormField text={"id"} />);
    const input = getByTestId("customInput");
    expect(input).toHaveProperty("id", "id");
  });

  /*
  it("Input onChangeMethod working",()=>{
    const { getByTestId } = render(<FormField type={"text"} inputName={"Name"} text={"Name"}/>);
    const input = getByTestId('customInput')
    expect(input).toHaveProperty("onChange","Method");
  });
  */
});
