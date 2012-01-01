using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using SQLiteBrowserNet.Model;

namespace SQLiteBrowserNet.ViewModel
{
    class TreeNodeVM
    {
        readonly ReadOnlyCollection<TreeNodeVM> _children;
        readonly TreeNodeVM _parent;
        readonly TreeNode _node;

        public TreeNodeVM(TreeNode node)
            :this(node, null)
        {
        }

        public TreeNodeVM(TreeNode node, TreeNodeVM parent)
        {
            _node = node;
            _parent = parent;

            _children = new ReadOnlyCollection<TreeNodeVM>(
                (from child in _node.Children
                 select new TreeNodeVM(child, this))
                 .ToList<TreeNodeVM>());
        }

        public ReadOnlyCollection<TreeNodeVM> Children
        {
            get { return _children; }
        }

        public string Name
        {
            get { return _node.Name; }
        }
    }
}
