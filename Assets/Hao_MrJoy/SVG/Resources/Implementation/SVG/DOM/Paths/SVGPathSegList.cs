using System.Collections.Generic;

public class SVGPathSegList {
  private List<object> _segList = new List<object>();
  public int Count { get { return _segList.Count; } }
  /***********************************************************************************/
  public SVGPathSegList() {
  }
  /***********************************************************************************/
  public void Clear() {
    this._segList.Clear();
  }
  //-----------
  public SVGPathSeg Initialize(SVGPathSeg newItem) {
    Clear();
    return AppendItem(newItem);
  }
  //-----------
  public SVGPathSeg GetItem(int index) {
    if(index < 0 || index > _segList.Count) {
      return null;
    }
    return(SVGPathSeg)this._segList[index];
  }
  //-----------
  public SVGPathSeg AppendItem(SVGPathSeg newItem) {
    this._segList.Add(newItem);
    SetList(newItem);
    return newItem;
  }
  /***********************************************************************************/
  internal SVGPathSeg GetPreviousSegment(SVGPathSeg seg) {
    int index =  this._segList.IndexOf(seg);
    if(index <= 0) {
      return null;
    } else {
      return(SVGPathSeg)GetItem(index - 1);
    }
  }
  /***********************************************************************************/
  private void SetList(SVGPathSeg newItem) {
    if(newItem != null)
      newItem.SetList(this);
  }
}