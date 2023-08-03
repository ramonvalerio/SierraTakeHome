import RegisterBox from "../../organisms/RegisterBox/RegisterBox";
import { RegisterAction } from "../../reducers/RegisterReducer/RegisterActions";
import { RegisterState } from "../../reducers/RegisterReducer/RegisterState";
import "./registerTemplate.css";

interface RegisterTemplateProps {
  state: RegisterState,
  dispatch: React.Dispatch<RegisterAction>
}

export default ({
  state,
  dispatch
}: RegisterTemplateProps) => {
  return (
    <div className="tp-register">
      <RegisterBox
        state={ state }
        dispatch={ dispatch } />
    </div>
  );
}