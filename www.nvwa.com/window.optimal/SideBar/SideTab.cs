using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using platform.include;

namespace window.optimal
{
    public class SideTab : Headstream, IUpdate
    {
        public override void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mMemberStreams, @"memberStreams");
            nSerialize._serialize(ref mSideTabImageUrl, @"sideTabImageUrl");
            nSerialize._serialize(ref mSideTabItems, @"sideTabItems");
            nSerialize._serialize(ref mSideTabName, @"sideTabName");
            nSerialize._serialize(ref mVisible, @"visible");
        }

        public override string _streamName()
        {
            return @"sideTab";
        }

        public void _runInit()
        {
            ImageSingleton imageSingleton_ = __singleton<ImageSingleton>._instance();
            mSideTabImage = imageSingleton_._getImage(mSideTabImageUrl);
            foreach (SideTabItem i in mSideTabItems)
            {
                i._runInit();
            }
            UpdateSingleton updateSingleton_ = __singleton<UpdateSingleton>._instance();
            updateSingleton_._registerUpdate(this);
        }

        public void _drawTabContent(Graphics nGraphics, Font nFont, Rectangle nRectangle)
        {
            int itemHeight_ = 20;
            for (int i = 0; i + mScrollIndex < mSideTabItems.Count; ++i)
            {
                SideTabItem sideTabItem_ = mSideTabItems[mScrollIndex + i];
                if (nRectangle.Height < i * itemHeight_)
                {
                    break;
                }
                sideTabItem_._drawItem(nGraphics, nFont, new Rectangle(nRectangle.X, nRectangle.Y + i * itemHeight_, nRectangle.Width, itemHeight_));
            }
        }

        public void _drawTabHeader(Graphics nGraphics, Font nFont, Rectangle nRectangle)
        {
            int width_ = nRectangle.Height - 2;
            switch (mSideTabStatus)
            {
                case SideTabStatus_.mNormal_:
                    ControlPaint.DrawBorder3D(nGraphics, nRectangle, Border3DStyle.RaisedInner);
                    nGraphics.DrawImage(mSideTabImage, nRectangle.X + 1, nRectangle.Y + 1, width_, width_);
                    nGraphics.DrawString(mSideTabName, nFont, SystemBrushes.ControlText, new PointF(nRectangle.X + width_ + 2, nRectangle.Y + 2));
                    break;
                case SideTabStatus_.mSelected_:
                    ControlPaint.DrawBorder3D(nGraphics, nRectangle, Border3DStyle.Sunken);
                    nGraphics.DrawImage(mSideTabImage, nRectangle.X + 1, nRectangle.Y + 1, width_, width_);
                    nGraphics.DrawString(mSideTabName, nFont, SystemBrushes.ControlText, new PointF(nRectangle.X + width_ + 2, nRectangle.Y + 2));
                    break;
                case SideTabStatus_.mDragged_:
                    ControlPaint.DrawBorder3D(nGraphics, nRectangle, Border3DStyle.RaisedInner);
                    nRectangle.X += 1;
                    nRectangle.Y += 1;
                    nRectangle.Width -= 2;
                    nRectangle.Height -= 2;
                    nGraphics.FillRectangle(SystemBrushes.ControlDarkDark, nRectangle);
                    nGraphics.DrawString(mSideTabName, nFont, SystemBrushes.HighlightText, new PointF(nRectangle.X + width_ , nRectangle.Y));
                    break;
            }
        }

        public void _runReset()
        {
            if (mPointItem == mChoosedItem)
            {
                return;
            }
            this._setChoosedItem(mPointItem);
            mSideBar._reflashControl();
        }

        public void _selectToChoosed()
        {
            this._setChoosedItem(mSelectedItem);
        }

        public void _setChoosedItem(SideTabItem nSideTabItem)
        {
            if (null != mChoosedItem)
            {
                mChoosedItem._setSideTabItemStatus(SideTabItemStatus_.mNormal_);
            }
            mChoosedItem = nSideTabItem;
            if (null != mChoosedItem)
            {
                mChoosedItem._setSideTabItemStatus(SideTabItemStatus_.mChoosed_);
            }
        }

        public SideTabItem _getChoosedItem()
        {
            return mChoosedItem;
        }

        public void _setSelectedItem(SideTabItem nSideTabItem)
        {
            if (null != mSelectedItem && mSelectedItem != mChoosedItem)
            {
                mSelectedItem._setSideTabItemStatus(SideTabItemStatus_.mNormal_);
            }
            mSelectedItem = nSideTabItem;
            if (null != mSelectedItem && mSelectedItem != mChoosedItem)
            {
                mSelectedItem._setSideTabItemStatus(SideTabItemStatus_.mSelected_);
            }
        }

        public SideTabItem _getSelectedItem()
        {
            return mSelectedItem;
        }

        public SideTabItem _getItemAt(int nX, int nY)
        {
            int index_ = mScrollIndex + nY / 20;
            return (index_ >= 0 && index_ < mSideTabItems.Count) ? mSideTabItems[index_] : null;
        }

        public void _setSideTabStatus(SideTabStatus_ nSideTabStatus)
        {
            mSideTabStatus = nSideTabStatus;
        }

        public void _setScrollIndex(int nScrollIndex)
        {
            mScrollIndex = nScrollIndex;
        }

        public int _itemHeight()
        {
            return 20;
        }

        public void _setSideBar(SideBar nSideBar)
        {
            mSideBar = nSideBar;
        }

        public bool _isVisible()
        {
            return mVisible;
        }

        public void _runUpdate()
        {
            bool visible_ = mVisible;
            ConditionSingleton conditionSingleton_ = __singleton<ConditionSingleton>._instance();
            foreach (MemberStream i in mMemberStreams)
            {
                IEnumerable<ConditionStream> conditionStream_ = i._getConditionStreams();
                bool result_ = conditionSingleton_._validate(conditionStream_);
                string name_ = i._getName();
                string value_ = i._getValue();
                if (@"visible" == name_)
                {
                    if (@"false" == value_)
                    {
                        mVisible = (!result_);
                    }
                    else
                    {
                        mVisible = result_;
                    }
                }
                else
                {
                }
            }
            if (visible_ != mVisible)
            {
                mSideBar._reflashControl();
            }
        }

        public SideTab()
        {
            mMemberStreams = new List<MemberStream>();
            mSideTabItems = new List<SideTabItem>();

            mPointItem = new SideTabItem();
            mPointItem._setName(@"选择");
            mPointItem._setId(@"selectPointor");
            mPointItem._setMail("zyouhua@gmail.com");
            mPointItem._setSideTabItemStatus(SideTabItemStatus_.mChoosed_);
            string imageUrl_ = @"rid://window.optimal.selectImageUrl";
            mPointItem._setImageUrl(imageUrl_);
            mSideTabItems.Add(mPointItem);

            mSideTabStatus = SideTabStatus_.mNormal_;
            mSideTabImageUrl = null;
            mSideTabImage = null;
            mSelectedItem = null;
            mChoosedItem = mPointItem;
            mSideTabName = null;
            mScrollIndex = 0;
            mVisible = true;
            mSideBar = null;
        }

        List<MemberStream> mMemberStreams;
        List<SideTabItem> mSideTabItems;
        SideTabStatus_ mSideTabStatus;
        SideTabItem mSelectedItem;
        SideTabItem mChoosedItem;
        string mSideTabImageUrl;
        SideTabItem mPointItem;
        string mSideTabName;
        Image mSideTabImage;
        SideBar mSideBar;
        int mScrollIndex;
        bool mVisible;
    }
}
