using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {


	public Transform target;
	float speed = 3;
	Vector3[] path;
	int targetIndex;

	public bool isSelect;

	public GameObject markPrefab; 
	public GameObject mark;

	void Start() {
		PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
	}

	void Update() {

		// Обработка нажатия на правую кнопку мыши(создание метки и направления пути)
		if(Input.GetMouseButtonDown(1)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2d = new Vector2(mousePos.x, mousePos.y);
			RaycastHit2D hit = Physics2D.Raycast(mousePos2d, Vector2.zero);
		
			
			if(mark != null) {
				Destroy(mark);
			}

			Debug.Log(hit.collider.tag);

			if(hit.collider.tag == "Build") {
				Vector2 buildtPos = new Vector2(hit.collider.transform.position.x - 1.5f, hit.collider.transform.position.y);
				mark = Instantiate(markPrefab, buildtPos, Quaternion.identity);
				target = mark.transform;


				Mark markComp = mark.GetComponent<Mark>();
				markComp.target = hit.collider.gameObject;

				Build buildComp = hit.collider.GetComponent<Build>();
				buildComp.countUnits = 1;

				PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
				return;
			}

			if(hit.collider.tag == "Button") {
				Vector2 buttonPos = new Vector2(hit.collider.transform.position.x - 0.7f, hit.collider.transform.position.y);
				mark = Instantiate(markPrefab, buttonPos, Quaternion.identity);
				target = mark.transform;


				Mark markComp = mark.GetComponent<Mark>();
				markComp.target = hit.collider.gameObject;

				PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
				return;
			}

			if(hit.collider.tag != "Wall") {
				
				mark = Instantiate(markPrefab, mousePos2d, Quaternion.identity);
				target = mark.transform;
				PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);				
			}


	


		}
	}
	// Остановка при столкновении с поставленной меткой
    private void OnCollisionEnter2D(Collision2D collision) {
		
        if (collision.collider.tag == "Mark") {  
			Mark markComp = mark.GetComponent<Mark>();
			
			if(markComp.target.tag == "Build") {
				Destroy(gameObject);
			}

			if(markComp.target.tag == "Button") {
				Button butComp = markComp.target.GetComponent<Button>();
				butComp.changeSprite();
			}
        }
    }

	private void moveOff() {
		target = transform;
		PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
	}

// Назначение пути Юниту
	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
			path = newPath;
			targetIndex = 0;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

// Движение юнита по пути
	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];
		while (true) {
			if (transform.position == currentWaypoint) {
				targetIndex ++;
				if (targetIndex >= path.Length) {
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);
			yield return null;

		}
	}

// Отладка
	public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex) {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}
}