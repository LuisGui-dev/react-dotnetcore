import TitlePage from "../../components/TitlePage";
import { Button } from "react-bootstrap";
import { useHistory, useParams } from "react-router-dom";

export default function ClienteForm() {
  let history = useHistory();
  let { id } = useParams();

  return (
    <>
      <TitlePage title={"Cliente Detalhes " + (id !== undefined ? id : "")}>
        <Button variant="outline-secondary" onClick={() => history.goBack()}>
          <i className="fas fa-arrow-left me-2" />
          Voltar
        </Button>
      </TitlePage>
    </>
  );
}
